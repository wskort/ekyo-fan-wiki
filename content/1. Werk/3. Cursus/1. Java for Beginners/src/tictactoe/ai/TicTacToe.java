package tictactoe.ai;

import java.util.Scanner;

public class TicTacToe {

    static GameState game;
    static Board board;

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        menu();

        while (!game.isDone()) {
            parseInput(scan.nextLine());
        }
    }

    /**
     * Parse the raw input depending on GameState
     * @param input String
     */
    static void parseInput(String input) {
        switch (game) {
            case MENU:
                switch (input) {
                    case "exit":
                        game = GameState.EXIT;
                        break;
                    default:
                        try {
                            if (input.startsWith("start")) {
                                String[] command = input.split(" ");
                                if (command.length != 3) {
                                    throw new Exception("Bad parameters!");
                                }
                                for (int i = 1; i < 3; i++) {
                                    switch (command[i]) {
                                        case "user":
                                        case "easy":
                                        case "medium":
                                        case "hard":
                                            break;
                                        default:
                                            throw new Exception("Bad parameters!");
                                    }
                                }
                                setupGame(command[1], command[2]);
                            } else {
                                throw new Exception("Bad parameters!");
                            }
                        } catch (Exception e) {
                            System.out.println(e.getMessage());
                            menu();
                        }
                }
                break;
            case UNFINISHED:
                try {
                    board.playTurn(input);
                } catch (Exception e) {
                    if (!"Not a robot!".equals(e.getMessage())) {
                        System.out.println(e.getMessage());
                    }
                }
                setupTurn();
                break;
        }
    }

    /**
     * Print the menu question and wait for input.
     */
    static void menu() {
        game = GameState.MENU;
        System.out.print("Input command: ");
    }

    /**
     * Set up the board, then set up the first turn.
     * @param player1 String specifying player1
     * @param player2 String specifying player2
     */
    static void setupGame(String player1, String player2) {
        String input = "_________";
        try {
            game = GameState.UNFINISHED;
            board = new Board(input, player1, player2);
            setupTurn();
        } catch (Exception e) {
            System.out.println(e.getMessage());
            menu();
        }
    }

    /**
     * Setup turn
     */
    static void setupTurn() {
        switch (game) {
            case UNFINISHED:
                try {
                    board.botTurn();
                } catch (Exception e) {
                    System.out.print("Enter the coordinates: ");
                }
                break;
            case X_WINS:
            case O_WINS:
            case DRAW:
                System.out.println();
                menu();
        }
    }
}
