using System.Text;

public class SgfTree
{
    public SgfTree(IDictionary<string, string[]> data, params SgfTree[] children)
    {
        Data = data;
        Children = children;
    }

    public IDictionary<string, string[]> Data { get; }
    public SgfTree[] Children { get; }
}

public class SgfParser
{
    public static SgfTree ParseTree(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("Invalid SGF");

        var parser = new Parser(input);
        var tree = parser.ParseCollection();

        if (!parser.AtEnd) throw new ArgumentException("Unexpected content after parsing");

        return tree;
    }

    private class Parser(string text)
    {
        private readonly string _text = text;
        private int _pos;

        public bool AtEnd => _pos >= _text.Length;
        private char Peek() => _text[_pos];
        private char Next() => _text[_pos++];

        private void Expect(char c)
        {
            if (AtEnd || Next() != c) throw new ArgumentException($"Expected '{c}'");
        }

        // ( sequence )
        public SgfTree ParseCollection()
        {
            Expect('(');

            var sequence = ParseSequence();

            var children = new List<SgfTree>();
            while (!AtEnd && Peek() == '(')
                children.Add(ParseCollection());

            Expect(')');

            if (sequence.Count == 0)
                throw new ArgumentException("Tree with no nodes");

            var root = sequence[0];
            var allChildren = sequence.Skip(1).Concat(children).ToArray();

            return new SgfTree(root.Data, allChildren);
        }

        // node { node }
        private List<SgfTree> ParseSequence()
        {
            var nodes = new List<SgfTree>();

            while (!AtEnd && Peek() == ';')
                nodes.Add(ParseNode());

            return nodes;
        }

        // ; property*
        private SgfTree ParseNode()
        {
            Expect(';');

            var props = new Dictionary<string, string[]>();

            while (!AtEnd)
            {
                char c = Peek();

                if (c == ';' || c == '(' || c == ')')
                    break;

                if (!char.IsUpper(c))
                    throw new ArgumentException("Invalid property key");

                var key = ParseKey();
                var values = ParseValues();

                if (props.ContainsKey(key))
                    throw new ArgumentException("Duplicate property");

                props[key] = [.. values];
            }

            return new SgfTree(props);
        }

        private string ParseKey()
        {
            int start = _pos;

            while (!AtEnd && char.IsUpper(Peek()))
                _pos++;

            return start == _pos
                ? throw new ArgumentException("Invalid property key")
                : _text[start.._pos];
        }

        private List<string> ParseValues()
        {
            var values = new List<string>();

            while (!AtEnd && Peek() == '[')
                values.Add(ParseValue());

            return values.Count == 0
                ? throw new ArgumentException("Property without value")
                : values;
        }

        private string ParseValue()
        {
            Expect('[');

            var result = new List<char>();

            while (!AtEnd && Peek() != ']')
            {
                char c = Next();

                if (c == '\\')
                {
                    if (AtEnd) break;

                    char next = Next();

                    if (next == '\n') continue;

                    result.Add(next);
                }
                else
                {
                    if (char.IsWhiteSpace(c) && c != '\n')
                        result.Add(' ');
                    else
                        result.Add(c);
                }
            }

            Expect(']');
            return new string([.. result]);
        }
    }
}