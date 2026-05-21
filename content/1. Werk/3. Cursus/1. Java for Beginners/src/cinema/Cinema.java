package cinema;
import java.util.*;

public class Cinema {

    public static char[][] cinema;
    public static State state = State.TOTAL_ROWS;
    public static int rows;
    public static int columns;
    public static int rowNr;
    public static int seatNr;

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        start();
        while (state != State.END) {
            parseInput(scan.nextInt());
        }
    }

    public static void start() {
        System.out.println("Enter the number of rows:");
    }

    public static void generateCinema() {
        cinema = new char[rows][columns];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                cinema[i][j] = 'S';
            }
        }
    }

    public static void printCinema() {
        System.out.println();
        System.out.println("Cinema:");

        // This loop is for the seat numbers
        for (int j = 0; j <= columns; j++) {
            if (j == 0) {
                System.out.print("  ");
            } else {
                System.out.print(j + " ");
            }
        }
        System.out.println();

        // Now we print the chart itself
        for (int i = 0; i < rows; i++) {
            System.out.print((i + 1) + " ");      // Row numbers in front
            for (int j = 0; j < columns; j++) {
                System.out.print(cinema[i][j] + " ");
            }
            System.out.println();
        }

        menu();
    }

    public static void buySeat() {
        System.out.println();
        if (rowNr > 0 && rowNr <= rows  && seatNr > 0 && seatNr <= columns) {
            if (cinema[rowNr - 1][seatNr - 1] == 'S') {
                System.out.println("Ticket price: $" + calcSeatPrice());
                cinema[rowNr - 1][seatNr - 1] = 'B';
                menu();
            } else {
                System.out.println("That ticket has already been purchased!");
                chooseSeat();
            }
        } else {
            System.out.println("Wrong input!");
            chooseSeat();
        }
    }

    public static int calcSeatPrice() {
        return calcSeatPrice(rowNr);
    }

    public static int calcSeatPrice(int row) {
        if (rows * columns < 60) {
            return 10;
        } else {
            if (rows / 2 >= (row)) {
                return 10;
            } else {
                return 8;
            }
        }
    }

    enum State {
        TOTAL_ROWS,
        TOTAL_COLUMNS,
        ROW_NR,
        SEAT_NR,
        END,
        MENU
    }

    public static void menu() {
        System.out.println();
        System.out.println("1. Show the seats");
        System.out.println("2. Buy a ticket");
        System.out.println("3. Statistics");
        System.out.println("0. Exit");
        state = State.MENU;
    }

    public static void printStatistics() {
        int ticketsSold = 0;
        int currentIncome = 0;
        int maxIncome = 0;

        // For each seat in the room:
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                int ticket = calcSeatPrice(i + 1);     // Calculate the seat price
                maxIncome += ticket;                        // Add it to max profit
                if (cinema[i][j] == 'B') {                  // And if it was sold:
                    ticketsSold++;                          // Count it
                    currentIncome += ticket;                // And count the cash
                }
            }
        }

        double percentageFilled = ticketsSold;
        percentageFilled = percentageFilled / (rows * columns);
        percentageFilled = percentageFilled * 100;

        System.out.println();
        System.out.printf("Number of purchased tickets: %d %n", ticketsSold);
        System.out.printf("Percentage: %.2f%c %n", percentageFilled, '%');
        System.out.printf("Current income: $%d %n", currentIncome);
        System.out.printf("Total income: $%d %n", maxIncome);

        menu();
    }

    public static void chooseSeat() {
        System.out.println();
        System.out.println("Enter a row number:");
        state = State.ROW_NR;
    }

    public static void parseInput(int input) {
        switch (state) {
            case TOTAL_ROWS:
                rows = input;
                System.out.println("Enter the number of seats in each row:");
                state = State.TOTAL_COLUMNS;
                break;
            case TOTAL_COLUMNS:
                columns = input;
                generateCinema();
                menu();
                break;
            case MENU:
                switch (input) {
                    case 1:
                        printCinema();
                        break;
                    case 2:
                        chooseSeat();
                        break;
                    case 3:
                        printStatistics();
                        break;
                    case 0:
                        state = State.END;
                        break;
                }
                break;
            case ROW_NR:
                rowNr = input;
                System.out.println("Enter a seat number in that row:");
                state = State.SEAT_NR;
                break;
            case SEAT_NR:
                seatNr = input;
                buySeat();
                break;
        }
    }
}
