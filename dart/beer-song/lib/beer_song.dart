class BeerSong {
  List<String> recite(int start, int count) {
    return List.generate(count, (index) => _gen(start - index)).fold(
        [],
        (previousValue, element) => [
              ...(previousValue.length > 0)
                  ? [...previousValue, '']
                  : previousValue,
              ...element
            ]);
  }

  List<String> _gen(int n) {
    final word = (int x) => x > 1 ? 'bottles' : 'bottle';

    if (n == 0) {
      return [
        'No more bottles of beer on the wall, no more bottles of beer.',
        'Go to the store and buy some more, 99 bottles of beer on the wall.'
      ];
    }

    return [
      '$n ${word(n)} of beer on the wall, $n ${word(n)} of beer.',
      n == 1
          ? 'Take it down and pass it around, no more bottles of beer on the wall.'
          : 'Take one down and pass it around, ${n - 1} ${word(n - 1)} of beer on the wall.'
    ];
  }
}
