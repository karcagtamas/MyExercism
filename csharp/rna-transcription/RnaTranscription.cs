public static class RnaTranscription
{
    public static string ToRna(string strand) => string.Join("", strand.Select(ch =>
                                                      {
                                                          return ch switch
                                                          {
                                                              'G' => 'C',
                                                              'C' => 'G',
                                                              'T' => 'A',
                                                              'A' => 'U',
                                                              _ => ' '
                                                          };
                                                      }));
}