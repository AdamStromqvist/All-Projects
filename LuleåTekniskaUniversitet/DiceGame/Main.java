package LuleåTekniskaUniversitet.DiceGame;

import java.util.Random;
import java.util.Scanner;

/**
 * Main - A simple game where the player rolls three dice to try to reach a sum of 12.
 * 
 * Pseudocode:
 * 1. Print welcome message.
 * 2. Loop until player quits:
 *    - Reset dice values and roll status.
 *    - Allow the player to roll each die exactly once.
 *    - Validate input and prevent re-rolling the same die.
 *    - Compute the sum after three rolls.
 *    - Determine win/loss conditions.
 *    - Display results and start a new round.
 * 3. End game when the player enters 'q'.
 * 
 * @author Adam Strömqvist
 */

public class Main {
    private static final int MAX_DICE_VALUE = 6;
    private static final int WINNING_SUM = 12;
    
    private static final String WELCOME_MESSAGE = "Welcome to dice game 12. You must roll 1-3 dice and try to get the sum of 12 ...";
    private static final String INVALID_INPUT_MESSAGE = "Sorry, that is an invalid entry. Try again. Valid entries are 1, 2, 3, and q";
    private static final String ALREADY_ROLLED_MESSAGE = "Sorry, you have already rolled that dice. Try again";
    private static final String WIN_MESSAGE = "You won!!";
    private static final String LOSS_MESSAGE = "You lost!!";
    private static final String NEXT_ROUND_MESSAGE = "Next round!\n";
    private static final String GAME_OVER_MESSAGE = "Game Over!";

    public static void main(final String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        int wins = 0;
        int losses = 0;
        boolean running = true;

        System.out.println(WELCOME_MESSAGE);

        while (running) {
            int dice1 = 0;
            int dice2 = 0;
            int dice3 = 0;
            boolean rolled1 = false;
            boolean rolled2 = false;
            boolean rolled3 = false;
            int rolls = 0;
            
            while (rolls < 3) {
                System.out.print("Enter which dice you want to roll [1,2,3] (exit with q): ");
                String input = scanner.nextLine().trim();

                if (input.equals("q")) {
                    running = false;
                    break;
                }

                if (input.equals("1")) {
                    if (!rolled1) {
                        dice1 = random.nextInt(MAX_DICE_VALUE) + 1;
                        rolled1 = true;
                        rolls++;
                    } else {
                        System.out.println(ALREADY_ROLLED_MESSAGE);
                        continue;
                    }
                } else if (input.equals("2")) {
                    if (!rolled2) {
                        dice2 = random.nextInt(MAX_DICE_VALUE) + 1;
                        rolled2 = true;
                        rolls++;
                    } else {
                        System.out.println(ALREADY_ROLLED_MESSAGE);
                        continue;
                    }
                } else if (input.equals("3")) {
                    if (!rolled3) {
                        dice3 = random.nextInt(MAX_DICE_VALUE) + 1;
                        rolled3 = true;
                        rolls++;
                    } else {
                        System.out.println(ALREADY_ROLLED_MESSAGE);
                        continue;
                    }
                } else {
                    System.out.println(INVALID_INPUT_MESSAGE);
                    continue;
                }
                
                int sum = dice1 + dice2 + dice3;
                System.out.println(dice1 + " " + dice2 + " " + dice3 + " sum: " + sum + " #win: " + wins + " #loss: " + losses);
            }
            
            if (running) {
                int sum = dice1 + dice2 + dice3;
                if (sum == WINNING_SUM) {
                    System.out.println(WIN_MESSAGE);
                    wins++;
                } else if (sum > WINNING_SUM) {
                    System.out.println(LOSS_MESSAGE);
                    losses++;
                } else {
                    System.out.println("You neither won nor lost the game.");
                }
                System.out.println(NEXT_ROUND_MESSAGE);
            }
        }
        
        System.out.println("#win: " + wins + " #loss: " + losses);
        System.out.println(GAME_OVER_MESSAGE);
        scanner.close();
    }
}

