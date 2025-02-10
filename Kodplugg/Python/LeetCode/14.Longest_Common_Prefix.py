class Solution:
    def longestCommonPrefix(self, strs):
        """
        :type strs: List[str]
        :rtype: str
        """
        if not strs:
            return ""
        
        # Hitta den kortaste strängen i listan som en gräns för prefixet
        shortest = min(strs, key=len)
        
        # Gå igenom varje tecken i den kortaste strängen
        for i, char in enumerate(shortest):
            # Jämför tecknet i den kortaste strängen med motsvarande tecken i de andra strängarna
            for other in strs:
                if other[i] != char:
                    # Om en skillnad hittas, returnera prefixet upp till den punkten
                    return shortest[:i]
        
        # Om ingen skillnad hittas, är hela den kortaste strängen prefixet
        return shortest

solution = Solution()
print(solution.longestCommonPrefix(["flower", "flow", "flight"]))  # Output: "fl"
print(solution.longestCommonPrefix(["dog", "racecar", "car"]))    # Output: ""
