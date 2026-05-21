package machine;
import java.util.Scanner;

public abstract class CoffeeMachine {
    // Starting supply:
    static int water = 400;
    static int milk = 540;
    static int beans = 120;
    static int cups = 9;
    static int cash = 550;

    // Machine states
    enum State {
        START, BUY, FILL_WATER, FILL_MILK, FILL_BEANS, FILL_CUPS, EXIT
    }

    // Starting state
    static State state;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        topMenu(false);

        while (state != State.EXIT) {
            processInput(scanner.nextLine());
        }
    }

    static void topMenu() {
        topMenu(true);
    }

    static void topMenu(boolean enter) {
        if (enter) {
            System.out.println();
        }
        state = State.START;
        System.out.println("Write action (buy, fill, take, remaining, exit):");
    }

    static void doAction(String action) {
        System.out.println();

        switch (action) {
            case "buy":
                System.out.println("What do you want to buy? 1 - espresso, 2 - latte, 3 - cappuccino, back - to main menu:");
                state = State.BUY;
                break;
            case "fill":
                System.out.println("Write how many ml of water you want to add:");
                state = State.FILL_WATER;
                break;
            case "take":
                System.out.println("I gave you $" + cash);
                cash = 0;
                topMenu();
                break;
            case "remaining":
                printInventory();
                topMenu();
                break;
            case "exit":
                state = State.EXIT;
                break;
        }
    }

    static void processInput (String input){
        // System.out.println("> " + input);
        switch (state) {
            case START:
                doAction(input);
                break;
            case BUY:
                buy(input);
                break;
            case FILL_WATER:
                water += Integer.parseInt(input);
                System.out.println("Write how many ml of milk you want to add:");
                state = State.FILL_MILK;
                break;
            case FILL_MILK:
                milk += Integer.parseInt(input);
                System.out.println("Write how many grams of coffee beans you want to add:");
                state = State.FILL_BEANS;
                break;
            case FILL_BEANS:
                beans += Integer.parseInt(input);
                System.out.println("Write how many disposable cups of coffee you want to add:");
                state = State.FILL_CUPS;
                break;
            case FILL_CUPS:
                cups += Integer.parseInt(input);
                topMenu();
                break;
            case EXIT:
                break;
        }
    }

    static String prepare(String coffee) {
        switch (coffee) {
            case "1":
                if (water < 250) return "water";
                if (beans < 16) return "coffee beans";
                if (cups < 1) return "disposable cups";
                break;
            case "2":
                if (water < 350) return "water";
                if (milk < 75) return "milk";
                if (beans < 20) return "coffee beans";
                if (cups < 1) return "disposable cups";
                break;
            case "3":
                if (water < 200) return "water";
                if (milk < 100) return "milk";
                if (beans < 12) return "coffee beans";
                if (cups < 1) return "disposable cups";
                break;
        }
        return "success";
    }

    static void buy(String order) {
        String result = prepare(order);

        if (result == "success") {
            System.out.println("I have enough resources, making you a coffee!");
            switch (order) {
                case "1": // espresso
                    water -= 250;
                    beans -= 16;
                    cash += 4;
                    cups -= 1;
                    break;
                case "2": // latte
                    water -= 350;
                    milk -= 75;
                    beans -= 20;
                    cash += 7;
                    cups -= 1;
                    break;
                case "3": // cappuccino
                    water -= 200;
                    milk -= 100;
                    beans -= 12;
                    cash += 6;
                    cups -= 1;
                    break;
            }
        } else {
            System.out.println("Sorry, not enough " + result + "!");
        }
        topMenu();
    }

    static void printInventory() {
        System.out.println("The coffee machine has:");
        System.out.println(water + " ml of water");
        System.out.println(milk + " ml of milk");
        System.out.println(beans + " g of coffee beans");
        System.out.println(cups + " disposable cups");
        System.out.println("$" + cash + " of money");
    }
}