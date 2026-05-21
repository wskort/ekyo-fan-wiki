package minesweeper;

import java.util.Scanner;

class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.print("How many mines do you want on the field? ");
        int mines = scan.nextInt();

        Minefield field = new Minefield(mines);
        field.print();
    }
}
