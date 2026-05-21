package minesweeper;

import java.util.Random;

class Minefield {
    private char[][] field;
    private Random random = new Random();

    /**
     * Create an empty field
     */
    {
        field = new char[9][9];
        for (int i = 0; i < field.length; i++) {
            for (int j = 0; j < field[0].length; j++) {
                field[i][j] = '.';
            }
        }
    }

    /**
     * Spawn a random minefield with a given amount of mines.
     * @param mines the amount of mines to populate
     */
    Minefield(int mines) {
        /**
         * Spawn the required amount of mines
         */
        for (int i = 0; i < mines; i++) {
            placeRandomMine();
        }

        /**
         * Per empty field, count neighbouring mines and display number (if any)
         */
        for (int i = 0; i < field.length; i++) {
            for (int j = 0; j < field[0].length; j++) {
                int x = countNeighbouringMines(i, j);
                if (x > 0) {
                    field[i][j] = Character.forDigit(x,10);
                }
            }
        }
    }

    /**
     * Count the amount of neighbouring mines
     * @param x row
     * @param y column
     * @return amount of neighbouring mines
     */
    int countNeighbouringMines(int x, int y) {
        // We don't display counts for fields that *are* mines.
        if (field[x][y] == 'X') { return -1; }

        int count = 0;
        for (int i = -1; i < 2; i++) {
            for (int j = -1; j < 2; j++) {
                if(isMine(x+i, y+j)) {
                    count++;
                }
            }
        }
        return count;
    }

    /**
     * Check whether a specific cell contains a mine.
     * Cells that cannot logically exist, do not contain mines.
     * @param x row
     * @param y column
     * @return true if it's a mine
     */
    private boolean isMine(int x, int y) {
        if (x < 0 || y < 0 || x >= field.length || y >= field.length) {
            return false;
        }
        if (field[x][y] == 'X') {
            return true;
        }
        return false;
    }

    /**
     * Place 1 mine at a random, empty space.
     */
    void placeRandomMine() {
        // Create coordinates
        int x, y;

        // Choose random *empty* coordinates
        do {
            x = random.nextInt(9);
            y = random.nextInt(9);
        } while (field[x][y] != '.');

        // And place a bomb there
        field[x][y] = 'X';
    }

    /**
     * Print the minefield.
     */
    void print() {
        // Top line
        System.out.print(" |");
        for (int i = 1; i <= field[0].length; i++) {
            System.out.print(i);
        }
        System.out.println("|");

        for (var line : field) {
            for (char cell : line) {
                System.out.print(cell);
            }
            System.out.println();
        }
    }
}
