class Hamming {
    String left;
    String right;

    Hamming(String leftStrand, String rightStrand) {
        this.validate(leftStrand, rightStrand);
        this.left = leftStrand;
        this.right = rightStrand;

    }

    void validate(String leftStrand, String rightStrand) throws IllegalArgumentException {
        if (leftStrand.isEmpty() && !rightStrand.isEmpty()) {
            throw new IllegalArgumentException("left strand must not be empty.");
        }
        if (rightStrand.isEmpty() && !leftStrand.isEmpty()) {
            throw new IllegalArgumentException("right strand must not be empty.");
        }
        if (leftStrand.length() != rightStrand.length()) {
            throw new IllegalArgumentException("leftStrand and rightStrand must be of equal length.");
        }
    }

    int getHammingDistance() throws IllegalArgumentException {

        int count = 0;
        for (int i = 0; i < this.left.length(); i++) {
            if (this.left.charAt(i) != this.right.charAt(i)) {
                count++;
            }
        }
        return count;
    }

}
