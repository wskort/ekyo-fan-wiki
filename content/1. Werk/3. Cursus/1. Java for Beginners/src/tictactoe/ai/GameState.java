package tictactoe.ai;

enum GameState {
    MENU(false),
    UNFINISHED(false),
    DRAW(false),
    X_WINS(false),
    O_WINS(false),
    EXIT(true);

    final private boolean done;

    /**
     * Game state constructor
     * @param done is true if the game is finished.
     */
    GameState(boolean done) {
        this.done = done;
    }

    /**
     * Getter of (bool) done
     * @return done
     */
    boolean isDone() {
        return done;
    }
}
