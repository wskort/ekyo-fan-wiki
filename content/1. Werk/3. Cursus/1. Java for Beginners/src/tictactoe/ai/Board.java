package tictactoe.ai;

class Board {

    char[][] board = new char[3][3];
    final private Player player1;
    final private Player player2;
    final int[][] triplets = {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {2,4,6}
    };

    /**
     * Board constructor converts string into initial board configuration
     * @param input String should be length=9 and all [XO_]
     * @throws Exception if the length is wrong
     * @throws Exception if an invalid character is passed
     * @throws Exception (pass) if a cell is already occupied
     * @throws Exception if the board configuration is invalid
     * @see #setMark(char, int)
     * @see #isValid()
     */
    Board(String... input) throws Exception {

        input[0] = input[0].trim();
        if (input[0].length() != 9) {
            throw new Exception("There should be 9 cells!");
        }
        // (try to) set each character on the board.
        for (int i = 0; i < 9; i++) {
            switch (input[0].charAt(i)) {
                case 'X':
                case 'O':
                case '_':
                    setMark(input[0].charAt(i), i);
                    break;
                default:
                    throw new Exception(input[0].charAt(i) + " is not a valid character!");
            }
        }
        if (!isValid()) {
            throw new Exception("That is not a legal setup!");
        }
        printBoard();
        player1 = new Player(input[1], 'X');
        player2 = new Player(input[2], 'O');
    }

    /**
     * Print a visual representation of the board.
     */
    void printBoard() {
        System.out.println("---------");
        for (var row : board) {
            System.out.print("| ");
            for (char c : row) {
                System.out.print(c + " ");
            }
            System.out.println("|");
        }
        System.out.println("---------");
    }

    /**
     * Read coordinates and (if valid) play the turn.
     * @param input String of raw input
     * @throws Exception unless exactly 2 coordinates are passed
     * @throws Exception if non-numeric coordinates are passed
     * @throws Exception (pass) if the cell is occupied
     * @throws Exception if coordinates are out of bounds
     * @see #currentPlayer()
     * @see #setMark(char, int, int)
     * @see #isInRange(int)
     */
    void playTurn(String input) throws Exception {
        String[] coordinates = input.split(" ");
        if (coordinates.length != 2) {
            throw new Exception("There should be 2 coordinates!");
        }
        int row;
        int column;
        try {
            row = Integer.parseInt(coordinates[0]);
            column = Integer.parseInt(coordinates[1]);
        } catch (Exception e) {
            throw new Exception("You should enter numbers!");
        }
        if (isInRange(row) && isInRange(column)) {
            char c = currentPlayer();
            setMark(c, row, column);
        } else {
            throw new Exception("Coordinates should be from 1 to 3!");
        }
        endTurn();
    }

    /**
     * Check the board for win-conditions and update the GameState.
     * @throws Exception (pass)
     * @see Player
     * @see #playTurn(String)
     */
    private void endTurn() throws Exception {
        printBoard();
        if (charWins('X')) {
            TicTacToe.game = GameState.X_WINS;
            System.out.println("X wins");
            menu();
        } else if (charWins('O')) {
            TicTacToe.game = GameState.O_WINS;
            System.out.println("O wins");
            menu();
        } else if (countChar('X') + countChar('O') == 9) {
            TicTacToe.game = GameState.DRAW;
            System.out.println("Draw");
            menu();
        } else {
            botTurn();
        }
    }

    /**
     * Return to menu state.
     */
    private void menu() {
        System.out.println();
        TicTacToe.menu();
    }

    /**
     * If a bot is at play, it makes a move and ends its turn.
     * @throws Exception (pass)
     */
    void botTurn() throws Exception {
        if (currentPlayer() == 'X' && !"user".equals(player1.playerType)) {
            setMark(currentPlayer(), player1.play());
            endTurn();
        } else if (currentPlayer() == 'O' && !"user".equals(player2.playerType)) {
            setMark(currentPlayer(), player2.play());
            endTurn();
        } else {
            throw new Exception("Not a robot!");
        }
    }

    /**
     * Return the character of the active player
     * @return char 'X' or 'O'
     * @see #countChar(char)
     */
    char currentPlayer() {
        if (countChar('X') == countChar('O')) {
            return 'X';
        } else {
            return 'O';
        }
    }

    /**
     * Verify that a coordinate number is in the correct range.
     * @param x coordinate number
     * @return boolean
     */
    private boolean isInRange(int x) {
        return x >= 1 && x <= 3;
    }

    /**
     * Check that the board is in a valid configuration.
     * @return boolean valid
     * @see #countChar(char)
     * @see #charWins(char)
     */
    private boolean isValid() {
        int x = countChar('X');
        int o = countChar('O');

        // if somehow both players are in a win-state, that's wrong
        if (charWins('X') && charWins('O')) {
            return false;
        }

        // Equal amounts X & O or 1 more X allowed.
        return x - o == 0 || x - o == 1;
        // And anything else is wrong.
    }

    /**
     * Count the amount of times a specific character occurs in a triplet of board indexes.
     * @param c the character to count
     * @param triplet valid trio of board coordinates that form a line
     * @return int count
     * @see #triplets each triplet in triplets can be counted with this method.
     */
    int countCharInTriplet(char c, int[] triplet) {
        int count = 0;
        for (int i : triplet) {
            if (c == boardString().charAt(i)) {
                count++;
            }
        }
        return count;
    }

    /**
     * Check whether the passed character is in a win-state by iterating over each valid line
     * @param c player
     * @return true if passed player wins.
     */
    boolean charWins(char c) {
        for (var triplet : triplets) {
            if (countCharInTriplet(c, triplet) == 3) {
                return true;
            }
        }
        return false;
    }

    /**
     * Count occurrences of a particular character on the board
     * @param x which character?
     * @return int count
     */
    int countChar(char x) {
        int i = 0;
        for (var row : board) {
            for (char c : row) {
                if (x == c) {
                    i++;
                }
            }
        }
        return i;
    }

    /**
     * Redirect index-based call to coordinate-based call.
     * @param c character to be set
     * @param index int 0-8
     * @throws Exception (pass) if the cell is occupied
     * @see #setMark(char, int, int)
     */
    private void setMark(char c, int index) throws Exception {
        if (c == '_') {
            c = ' ';
        }
        index++;
        if (index <= 3) {
            setMark(c, 1, index);
        } else if (index <= 6) {
            setMark(c, 2, index - 3);
        } else {
            setMark(c, 3, index - 6);
        }
    }

    /**
     * Set mark c at location (row, column)
     * @param c character ('X', 'O' or '_')
     * @param row int 1-3
     * @param column int 1-3
     * @throws Exception if the cell is occupied
     */
    private void setMark(char c, int row, int column) throws Exception {
        row--;                  // convert 1-3 to 0-2
        column--;               // convert 1-3 to 0-2

        if (board[row][column] == 'X' || board[row][column] == 'O') {
            throw new Exception ("This cell is occupied! Choose another one!");
        }
        board[row][column] = c;
    }

    /**
     * Generate a string version of the board for the AI.
     * @return the 9 characters in order (as String)
     */
    String boardString() {
        StringBuilder boardString = new StringBuilder(9);
        for (var row : board) {
            for (char c : row) {
                boardString.append(c);
            }
        }
        return boardString.toString();
    }
}
