package tictactoe.ai;

import java.util.Random;
import java.util.ArrayList;

class Player {
    final String playerType;
    final char me;
    final char notMe;

    Random random = new Random();

    /**
     * Initialize playerType, me and notMe.
     * @param playerType user/easy/medium/hard
     * @param me my character on the board
     * @see #playerType
     * @see #me
     * @see #notMe
     */
    Player(String playerType, char me) {
        if (me == 'O') {
            this.me = me;
            notMe = 'X';
        } else {
            this.me = 'X';
            notMe = 'O';
        }
        switch (playerType) {
            case "easy":
            case "medium":
            case "hard":
            case "user":
                this.playerType = playerType;
                break;
            default:
                this.playerType = "easy";
        }
    }

    /**
     * Choose a move to play depending on the AI difficulty. This method will only be called for non-humans.
     * @return int index of the move to be played.
     */
    int play() {
        System.out.print("Making move level \"");
        switch (playerType) {
            case "easy":
                return playEasy();
            case "medium":
                return playMedium();
            case "hard":
                return playHard();
        }
        return 0;
    }

    /**
     * Choose a random, unoccupied place on the board.
     * @return index of move
     */
    private int randomMove() {
        int index;
        do {
            index = random.nextInt(9);
        } while (TicTacToe.board.boardString().charAt(index) != ' ');
        return index;
    }

    /**
     * Follow easy play rules:
     * 1. Choose random move.
     * @return index of move
     * @see #randomMove()
     */
    private int playEasy() {
        System.out.println("easy\"");
        return randomMove();
    }

    /**
     * For each line of three characters:
     *     if two are the matching character and the third is empty
     *        then return the index of the empty field
     * If no matches are found, return -1.
     * @param c character to match
     * @return index of found potential win, or -1 if none are found.
     */
    private int findPotentialWin(char c) {
        for (var triplet : TicTacToe.board.triplets) {
            if (TicTacToe.board.countCharInTriplet(c, triplet) == 2 && TicTacToe.board.countCharInTriplet(' ', triplet) == 1) {
                for (int i = 0; i < 3; i++) {
                    if (TicTacToe.board.boardString().charAt(triplet[i]) == ' ') {
                        return triplet[i];
                    }
                }
            }
        }
        return -1;
    }

    /**
     * Follow medium play rules: choose first that applies
     * 1. Play winning move
     * 2. Block winning move
     * 3. Choose random move
     * @return index of move
     */
    private int playMedium() {
        System.out.println("medium\"");
        int step1 = findPotentialWin(me);
        if (step1 > -1) {
            return step1;
        }
        int step2 = findPotentialWin(notMe);
        if (step2 > -1) {
            return step2;
        }
        return randomMove();
    }

    /**
     * Play at hard difficulty:
     * Recursively check the win-value per field and play the best one.
     * @return index of move
     */
    private int playHard() {
        System.out.println("hard\"");

        StringBuilder currentStatus = new StringBuilder(TicTacToe.board.boardString());
        Move myMove = minimax(currentStatus);
        return myMove.getIndex();
    }

    /**
     * Generate a list of indexes of empty fields for a hypothetical board
     * @param board StringBuilder of the hypothetical board
     * @return ArrayList<Integer> with the indexes of empty spaces.
     * @see #minimax(StringBuilder)
     */
    private ArrayList<Integer> emptyIndexes(StringBuilder board) {
        ArrayList<Integer> list = new ArrayList<>();
        for (int i = 0; i < board.length(); i++) {
            if (board.charAt(i) == ' ') {
                list.add(i);
            }
        }
        return list;
    }

    /**
     * Count the amount of times a specific character occurs in a triplet of board indexes.
     * @param c the character to count
     * @param triplet valid trio of board coordinates that form a line
     * @return int count
     * @see Board#triplets each triplet in triplets can be counted with this method.
     * @see Board#countCharInTriplet(char, int[]), this overloads it.
     * @see #minimax(StringBuilder)
     */
    private int countCharInTriplet(char c, int[] triplet, StringBuilder boardStatus) {
        int count = 0;
        for (int i : triplet) {
            if (c == boardStatus.charAt(i)) {
                count++;
            }
        }
        return count;
    }

    /**
     * Check whether the passed character is in a win-state by iterating over each valid line
     * @param c player
     * @return true if passed player wins.
     * @see Board#charWins(char), this overloads it
     * @see #minimax(StringBuilder)
     */
    private boolean charWins(char c, StringBuilder boardStatus) {
        for (var triplet : TicTacToe.board.triplets) {
            if (countCharInTriplet(c, triplet, boardStatus) == 3) {
                return true;
            }
        }
        return false;
    }

    /**
     * Recursively find the best move to play by recursively thinking out all options.
     * @param boardStatus current BoardString
     * @return {int score, int index}
     */
    private Move minimax(StringBuilder boardStatus) {

        // a list of the available spots
        var availSpots = emptyIndexes(boardStatus);

        // an array to collect the score per index
        Move[] moves = new Move[availSpots.size()];

        // loop through available spots
        for (int i = 0; i < availSpots.size(); i++) {
            // create new board version
            StringBuilder newBoard = new StringBuilder(boardStatus.toString());
            newBoard = newBoard(newBoard, availSpots.get(i));

            // set the corresponding score
            if (charWins(me, newBoard)) {
                moves[i] = new Move(10, availSpots.get(i));
            } else if (charWins(notMe, newBoard)) {
                moves[i] = new Move(-10, availSpots.get(i));
            } else if (emptyIndexes(newBoard).size() == 0) {
                moves[i] = new Move(0, availSpots.get(i));
            } else {
                moves[i] = new Move (minimax(newBoard).getScore(), availSpots.get(i));
            }
        }

        // find the best move
        Move bestMove;
        // if it's my turn, choose the move with the highest score
        if (activePlayer(boardStatus) == me) {
            bestMove = new Move(-100, -1);
            for (int i = 0; i < moves.length; i++) {
                if (moves[i].getScore() > bestMove.getScore()) {
                    bestMove = moves[i];
                }
            }
        } else { // and if it's not, choose the move with the lowest score for the other player
            bestMove = new Move(100,-1);
            for (int i = 0; i < availSpots.size(); i++) {
                if (moves[i].getScore() < bestMove.getScore()) {
                    bestMove = moves[i];
                }
            }
        }

        return bestMove;
    }

    /**
     * Determine the character of the active player (the next to place a mark).
     * @param board The current board state to be evaluated.
     * @return the character of the active player
     */
    private char activePlayer(StringBuilder board) {
        int countX = 0;
        int countO = 0;
        for (int i = 0; i < board.length(); i++) {
            if (board.charAt(i) == 'X') { countX++; }
            if (board.charAt(i) == 'O') { countO++; }
        }
        if (countX > countO) {
            return 'O';
        } else {
            return 'X';
        }
    }

    /**
     * Place a (hypothetical) move in the passed StringBuilder on the passed index.
     * Choose 'X' or 'O' depending on whose turn it would be.
     * @param board the StringBuilder to be adjusted
     * @param index at which position the mark should be made
     * @return the altered board
     */
    private StringBuilder newBoard(StringBuilder board, int index) {
        board.setCharAt(index, activePlayer(board));
        return board;
    }
}