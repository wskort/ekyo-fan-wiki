package tictactoe.ai;

class Move {
    private int score;
    private int index;

    /**
     * We could just make this an array, but I like the readability of an object.
     * @param score an int representing the score
     * @param index the value of the field, from 0-8.
     */
    Move(int score, int index) {
        this.score = score;
        this.index = index;
    }

    /**
     * Get score
     * @return score
     */
    int getScore() {
        return score;
    }

    /**
     * Get index
     * @return index
     */
    int getIndex() {
        return index;
    }

    @Override
    public String toString() {
        return index + " (" + score + ")";
    }
}