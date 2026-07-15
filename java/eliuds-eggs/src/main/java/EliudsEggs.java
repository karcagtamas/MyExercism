public class EliudsEggs {
    public int eggCount(int number) {
        int cnt = 0;

        while (number > 0) {
            cnt += number & 1;
            number >>= 1;
        }

        return cnt;
    }
}
