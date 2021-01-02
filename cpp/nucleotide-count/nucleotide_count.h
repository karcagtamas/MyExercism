#if !defined(NUCLEOTIDE_COUNT_H)
#define NUCLEOTIDE_COUNT_H

#include <string>
#include <map>

namespace nucleotide_count
{
    class counter
    {
    private:
        std::string dna;
        std::map<char, int> nuc;
        void calc();

    public:
        counter(const std::string &dna) : dna(dna)
        {
            nuc.insert({'A', 0});
            nuc.insert({'T', 0});
            nuc.insert({'C', 0});
            nuc.insert({'G', 0});
            calc();
        };
        std::map<char, int> nucleotide_counts() const;
        int count(char v) const;
    };
} // namespace nucleotide_count

#endif // NUCLEOTIDE_COUNT_H