package Kodplugg.Java.NeetCode.Arrays_and_Hashing;

import java.util.Arrays;

public class ValidAnagram {
    public boolean isAnagram(String s, String t) {
        if (s.length() != t.length()) {
            return false;
        }
        char[] sArray = s.toCharArray();
        char[] tArray = t.toCharArray();
        Arrays.sort(sArray);
        Arrays.sort(tArray);
        return Arrays.equals(sArray, tArray);
    }

    public static void main(String[] args) {
        ValidAnagram solution = new ValidAnagram();
        System.out.println("Test 1 (should be true): " + solution.isAnagram("anagram", "nagaram"));
        System.out.println("Test 2 (should be false): " + solution.isAnagram("rat", "car"));
    }
}