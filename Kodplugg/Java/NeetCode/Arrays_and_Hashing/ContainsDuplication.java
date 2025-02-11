package Kodplugg.Java.NeetCode.Arrays_and_Hashing;

import java.util.HashSet;

public class ContainsDuplication {
    public boolean hasDuplicate(int[] nums) {
        HashSet<Integer> seen = new HashSet<>();
        for (int num : nums) {
            if (!seen.add(num)) { // Om num redan finns i setet, returnera true
                return true;
            }
        }
        return false;
    }

    public static void main(String[] args) {
        ContainsDuplication solution = new ContainsDuplication();
        int[] testArray1 = {1, 2, 3, 4, 5};
        int[] testArray2 = {1, 2, 3, 4, 1};
        System.out.println("Test 1 (should be false): " + solution.hasDuplicate(testArray1));
        System.out.println("Test 2 (should be true): " + solution.hasDuplicate(testArray2));
    }
}