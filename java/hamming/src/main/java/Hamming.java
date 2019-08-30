class Hamming {
    String left;
    String right;

    Hamming(String leftStrand, String rightStrand) {
        this.left = leftStrand;
        this.right = rightStrand;
    }

    int getHammingDistance() throws IllegalArgumentException {
        if (this.left.length() != this.right.length()){
            System.out.println("Bad");
            throw new IllegalArgumentException("leftStrand and rightStrand must be of equal length.");
        }else{
            if (this.left.isEmpty() && !this.right.isEmpty()){
                throw new IllegalArgumentException("left strand must not be empty.");
            }
            if (this.right.isEmpty() && !this.left.isEmpty()){
                throw new IllegalArgumentException("right strand must not be empty.");
            }
        }
        int count = 0;
        for (int i = 0; i < this.left.length(); i++) {
            if (this.left.charAt(i) != this.right.charAt(i)){
                count++;
            }
        }
        return count;
    }

}
