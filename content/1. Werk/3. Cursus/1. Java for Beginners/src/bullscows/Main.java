package bullscows;

import java.util.Scanner;

public class Main {

    public static int turn = 0;
    public static State state = State.SETUP_LENGTH;
    public static Secret code;
    public static int length;

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        setup();

        while (state != State.EXIT) {
            parseInput(scan.next());
        }
    }

    /**
     * Initial screen setup
     */
    static void setup() {
        System.out.println("Input the length of the secret code:");
    }

    /**
     * Setup next turn.
     */
    static void nextTurn() {
        state = State.MAIN;
        turn++;
        System.out.printf("Turn %d. Answer:%n", turn);
    }

    static void error(String input, String error) {
        System.out.print("Error: ");
        switch (error) {
            case "NaN":
                System.out.print("\"" + input + "\" isn't a valid number.");
                break;
            case "range":
                System.out.print(input + " is not in the range 1-36.");
                break;
            case "symbols < length":
                System.out.print("It's not possible to generate a code with a length of ");
                System.out.print(length);
                System.out.print(" with " + input + " unique symbols.");
                break;
            case "invalid":
                System.out.print("\"" + input + "\" isn't a valid answer.");
                break;
            default:
                System.out.print("An unknown error occurred.");
        }
        state = State.EXIT;
    }

    /**
     * Process any incoming command.
     * @param input String
     */
    static void parseInput(String input) {
        if ("exit".equals(input)) {
            state = State.EXIT;
        }
        switch (state) {
            /**
             * First, collect the target length of the secret code.
             */
            case SETUP_LENGTH:
                try {
                    int num = Integer.parseInt(input);
                    if (num < 1 || num > 36) {
                        throw new Exception();
                    }
                    length = num;
                    System.out.println("Input the number of possible symbols in the code:");
                    state = State.SETUP_RANGE;
                } catch (NumberFormatException e) {
                    error(input, "NaN");
                } catch (Exception e) {
                    error(input, "range");
                }
                break;
            /**
             * Then collect the number of unique symbols allowed.
             */
            case SETUP_RANGE:
                try {
                    int num = Integer.parseInt(input);
                    if (num < 1 || num > 36) {
                        throw new Exception("range");
                    }
                    if (num < length) {
                        throw new Exception("symbols < length");
                    }
                    code = new Secret(length, num);
                    nextTurn();
                } catch (NumberFormatException e) {
                    error(input, "NaN");
                } catch (Exception e) {
                    error(input, e.getMessage());
                }
                break;
            /**
             * In the main state, check that the input is clean and use it to guess the secret.
             */
            case MAIN:
                if (code.clean(input)) {
                    boolean win = code.check(input);
                    if (win) {
                        System.out.println("Congratulations! You guessed the secret code.");
                        state = State.EXIT;
                    } else {
                        nextTurn();
                    }
                } else {
                    error(input, "invalid");
                }
                break;
        }
    }
}
