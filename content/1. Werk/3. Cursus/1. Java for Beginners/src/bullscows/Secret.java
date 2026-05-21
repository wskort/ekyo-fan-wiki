package bullscows;

import java.util.Random;

class Secret {

    /**
     * The secret code to be guessed!
     */
    private final String secret;
    private final int complexity;
    private final String symbols = "0123456789abcdefghijklmnopqrstuvwxyz";

    /**
     * Generate the secret code upon creation.
     * @param length of the secret code
     */
    Secret(int length, int complexity) {
        this.complexity = complexity;
        secret = random(length);
        describeSecret();
        System.out.println("Okay, let's start a game!");
    }

    /**
     * Print preparation result with complexity description.
     */
    private void describeSecret() {
        StringBuilder report = new StringBuilder();
        report.append("The secret is prepared: ");

        // **** with secret.length()
        for (int i = 0; i < secret.length(); i++) {
            report.append('*');
        }

        // (0-#, a-#).
        report.append(" (0-");
        if (complexity <= 10) {
            report.append(symbol(complexity - 1));
        } else {
            report.append("9, a");
            if (complexity > 11) {
                report.append("-");
                report.append(symbol(complexity - 1));
            }
        }
        report.append(").");
        System.out.println(report);
    }

    /**
     * Count the amount of correct numbers at the correct locations ('bulls').
     * @param input text to be compared to the secret
     * @return amount of 'bulls'
     */
    private int countBulls(String input) {
        int count = 0;
        for (int i = 0; i < secret.length(); i++) {
            if (secret.charAt(i) == input.charAt(i)) {
                count++;
            }
        }
        return count;
    }

    /**
     * Count the amount of correct numbers at incorrect locations ('cows').
     * @param input text to be compared to the secret
     * @param bulls amount of 'bulls'
     * @return amount of 'cows'
     */
    private int countCows(String input, int bulls) {
        int count = -bulls;                                                 // Fully correct numbers don't count!
        for (int i = 0; i < secret.length(); i++) {
            if (secret.contains(String.valueOf(input.charAt(i)))) {
                count++;
            }
        }
        return count;
    }

    /**
     * Present the result in natural language
     * @param bulls amount of 'bulls'
     * @param cows amount of 'cows'
     * @return formatted string listing results
     */
    private String formatResult(int bulls, int cows) {
        if (bulls + cows == 0) {
            return "Grade: None";
        } else {
            String str = "Grade: ";
            if (bulls > 0) {
                str = str + formatAmount(bulls, "bull");
                if (cows > 0) {
                    str = str + " and ";
                }
            }
            if (cows > 0) {
                str = str + formatAmount(cows, "cow");
            }
            return str;
        }
    }

    /**
     * Abstract formatter for "# animals" in natural language
     * @param num amount of animals
     * @param animal type of animal
     * @return formatted string
     */
    private String formatAmount(int num, String animal) {
        String str = num + " " + animal;                                    // # animal
        if (num > 1) {                                                      // if plural
            str = str + "s";                                                // add plural -s
        }
        return str;
    }

    /**
     * Check the user's guess by comparing it to the secret code.
     * @param answer user's guess
     * @return correct y/n
     */
    boolean check(String answer) {
        int bulls = countBulls(answer);
        int cows = countCows(answer, bulls);
        System.out.println(formatResult(bulls, cows));
        return bulls == secret.length();
    }

    /**
     * Generate a pseudo-random code with unique symbols
     * @param length of the code to be generated
     * @return String of the new secret
     */
    private String random(int length) {
        StringBuilder pseudo = new StringBuilder();
        Random random = new Random();
        while (pseudo.length() < length) {
            String n = symbol(random.nextInt(complexity));
            if (!pseudo.toString().contains(n)) {
                pseudo.append(n);
            }
        }
        return pseudo.toString();
    }

    /**
     * Get the n-th symbol from the alphanumeric range.
     * @param n index of symbol
     * @return single-character string with the symbol.
     */
    private String symbol(int n) {
        return Character.toString(symbols.charAt(n));
    }

    /**
     * This method checks that the input is a numeric string of right length.
     * @param input text to be validated
     * @return boolean safe to process y/n
     */
    boolean clean(String input) {
        if (input == null) {
            input = "";
        }
        if (symbolsValid(input) && input.length() == secret.length()) {
            return true;
        } else {
            return false;
        }
    }

    /**
     * Test whether all the symbols in the input string are allowed with the current complexity.
     * @param input String
     * @return valid y/n
     */
    private boolean symbolsValid(String input) {
        boolean valid = true;
        for (int i = 0; i < input.length(); i++) {
            String n = Character.toString(input.charAt(i));
            if (!symbols.substring(0, complexity).contains(n)) {
                valid = false;
            }
        }
        return valid;
    }
}
