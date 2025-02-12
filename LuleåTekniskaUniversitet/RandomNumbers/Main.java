package LuleåTekniskaUniversitet.RandomNumbers;

import java.util.Random;
import java.util.Scanner;

/**
 * RandomNumbers - A program that generates and sorts random numbers.
 *
 * Pseudocode:
 * 1. Ask the user for the number of random numbers to generate.
 *    - Validate input: must be an integer and within system limits.
 *    - Handle OutOfMemoryError if input is too large.
 * 2. Generate the random numbers (range 0-999) and store them in an array.
 * 3. Print the numbers in their original order.
 * 4. Separate even and odd numbers into two new arrays.
 * 5. Sort even numbers in ascending order.
 * 6. Sort odd numbers in descending order.
 * 7. Print the sorted even numbers, followed by '-', then the sorted odd numbers.
 * 8. Print the count of even and odd numbers.
 *
 * @author Adam Strömqvist
 */

public class Main {
    private static final String INVALID_INPUT_MESSAGE = "Invalid Input";
    private static final int MAX_RANDOM_VALUE = 999;

    public static void main(final String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        System.out.println("How many random numbers in the range 0 - 999 are desired?");

        int size;
        try {
            size = Integer.parseInt(scanner.nextLine().trim());
            if (size < 1) {
                throw new NumberFormatException();
            }
        } catch (NumberFormatException e) {
            System.out.println(INVALID_INPUT_MESSAGE);
            return;
        }

        int[] numbers;
        try {
            numbers = new int[size];
        } catch (OutOfMemoryError e) {
            System.out.println("Too many numbers requested. Unable to allocate memory.");
            return;
        }

        // Generate random numbers and store them in the array
        for (int i = 0; i < size; i++) {
            numbers[i] = random.nextInt(MAX_RANDOM_VALUE + 1);
        }

        // Print the unsorted numbers
        System.out.println("Here are the random numbers:");
        printArray(numbers);

        int[] evens;
        int[] odds;

        try {
            // Separate even and odd numbers
            int evenCount = 0;
            int oddCount = 0;
            for (int num : numbers) {
                if (num % 2 == 0) {
                    evenCount++;
                } else {
                    oddCount++;
                }
            }

            evens = new int[evenCount];
            odds = new int[oddCount];
            evenCount = 0;
            oddCount = 0;

            for (int num : numbers) {
                if (num % 2 == 0) {
                    evens[evenCount++] = num;
                } else {
                    odds[oddCount++] = num;
                }
            }
        } catch (OutOfMemoryError e) {
            System.out.println("Error allocating memory for sorting.");
            return;
        }

        // Sort evens in ascending order and odds in descending order
        bubbleSort(evens, true);
        bubbleSort(odds, false);

        // Print sorted numbers
        System.out.println("\nHere are the random numbers arranged:");
        if (evens.length > 0) {
            printArray(evens);
        } else {
            System.out.print("No Even Numbers");
        }

        System.out.print(" - ");

        if (odds.length > 0) {
            printArray(odds);
        } else {
            System.out.print("No Odd Numbers");
        }

        System.out.println("\nOf the above " + size + " numbers, " + evens.length + " were even and " + odds.length + " odd");
        scanner.close();
    }

    /**
     * Sorts an array using the Bubble Sort algorithm.
     * @param array the array to be sorted
     * @param ascending true if sorting in ascending order, false for descending
     */
    private static void bubbleSort(final int[] array, final boolean ascending) {
        int n = array.length;
        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - i - 1; j++) {
                if ((ascending && array[j] > array[j + 1]) || (!ascending && array[j] < array[j + 1])) {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    /**
     * Prints the elements of an array in a single line.
     * @param array the array to be printed
     */
    private static void printArray(final int[] array) {
        for (int i = 0; i < array.length; i++) {
            System.out.print(array[i] + (i < array.length - 1 ? " " : ""));
        }
    }
}

