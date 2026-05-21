package tictactoe.vs;
import java.util.*;

public class TicTacToe {

    static char[][] grid = new char[3][3];
    static GameState state = GameState.X_TURN;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        setupGame();

        while (state != GameState.END) {
            parseInput(scanner.nextLine());
        }
    }

    public static void setupGame() {
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                grid[x][y] = '_';
            }
        }
        printGrid();
        setupTurn(false);
    }

    public static void setupTurn() {
        setupTurn(true);
    }

    public static void setupTurn(boolean changePlayer) {
        System.out.print("Enter the coordinates: ");
        if (changePlayer) {
            switch (state) {
                case O_TURN:
                    state = GameState.X_TURN;
                    break;
                case X_TURN:
                    state = GameState.O_TURN;
                    break;
            }
        }
    }

    public static void parseInput(String input) {
        switch (state) {
            case X_TURN:
            case O_TURN:
                Location loc = new Location(input);
                if (loc.valid) {
                    putMark(loc);
                } else {
                    setupTurn(false);
                }
                break;
            default:
                break;
        }
    }

    public static void putMark(Location loc) {
        switch (grid[loc.row - 1][loc.column - 1]) {
            case 'X':
            case 'O':
                System.out.println("This cell is occupied! Choose another one!");
                setupTurn(false);
                break;
            default:
                grid[loc.row - 1][loc.column - 1] = state.c;
                printGrid();
                analyzeGrid();

                switch (state) {
                    case X_TURN:
                    case O_TURN:
                        setupTurn();
                        break;
                    default:
                        break;
                }
        }
    }

    public static void printGrid() {
        System.out.println("---------");
        for (char[] row : grid) {
            System.out.print("| ");
            for (char i : row) {
                if (i == '_') {
                    System.out.print("  ");
                } else {
                    System.out.print(i + " ");
                }
            }
            System.out.println("|");
        }
        System.out.println("---------");
    }

    public static int countChar(char letter) {
        int count = 0;
        for (var row : grid) {
            for (var c : row) {
                if (c == letter) {
                    count++;
                }
            }
        }
        return count;
    }

    public static boolean validGrid() {
        int x = countChar('X');
        int o = countChar('O');

        if (x - o > 1 || o - x > 1) {
            return false;
        }
        if (charWins('X') && charWins('O')) {
            return false;
        }

        return true;
    }

    public static boolean charWins(char letter) {
        boolean win = false;

        for (int i = 0; i < 3; i++) {
            if (grid[i][0] == letter && grid[i][1] == letter && grid[i][2] == letter) {
                win = true;
            }
            if (grid[0][i] == letter && grid[1][i] == letter && grid[2][i] == letter) {
                win = true;
            }
        }
        if (grid[0][0] == letter && grid[1][1] == letter && grid[2][2] == letter) {
            win = true;
        }
        if (grid[0][2] == letter && grid [1][1] == letter && grid [2][0] == letter) {
            win = true;
        }

        return win;
    }

    public static void analyzeGrid() {
        if (!validGrid()) {
            System.out.println("Impossible");
            state = GameState.END;
        } else if (charWins('X')) {
            System.out.println("X wins");
            state = GameState.END;
        } else if (charWins('O')) {
            System.out.println("O wins");
            state = GameState.END;
        } else if (countChar('X') + countChar('O') == 9) {
            System.out.println("Draw");
            state = GameState.END;
        }
    }

    static class Location {
        int row;
        int column;
        boolean valid;

        Location(String input) {
            if (input.length() < 3) {
                numError();
            } else {
                char a = input.charAt(0);
                char b = input.charAt(2);
                if (Character.isDigit(a) && Character.isDigit(b)) {
                    row = Character.getNumericValue(a);
                    column = Character.getNumericValue(b);
                    if (row < 1 || row > 3 || column < 1 || column > 3) {
                        rangeError();
                    } else {
                        valid = true;
                    }
                } else {
                    numError();
                }
            }
        }

        public void rangeError() {
            System.out.println("Coordinates should be from 1 to 3!");
            valid = false;
        }

        public void numError() {
            System.out.println("You should enter numbers!");
            valid = false;
        }
    }

    enum GameState {
        X_TURN('X'),
        O_TURN('O'),
        END('F');

        char c;

        GameState(char c) {
            this.c = c;
        }
    }
}