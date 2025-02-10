# Klass som använder swap med en for-loop och negativ indexering (~i)
class Solution:
    def reverseString(self, s):
        # Loopa över första halvan av listan
        for i in range(len(s) // 2):
            # Byt plats på elementet vid index i och elementet vid motsvarande plats från slutet (~i)
            s[i], s[~i] = s[~i], s[i]

solution = Solution()

# Exempelanvändning
string_list = ['h', 'e', 'l', 'l', 'o']
# Anropa metoden för att vända listan
solution.reverseString(string_list)

# Skriv ut den omvända listan, vilket blir ['o', 'l', 'l', 'e', 'h']
print(string_list)

# Två pekare metod
# Klass som använder två pekare för att vända listan
class Solution2:
    def reverseString2(self, s):
        # Sätt en pekare vid början (left) och en vid slutet (right) av listan
        left, right = 0, len(s) - 1
        # Fortsätt byta plats på elementen tills pekarna möts i mitten
        while left < right:
            # Byt plats på elementen vid left och right
            s[left], s[right] = s[right], s[left]
            # Flytta pekarna närmare varandra
            left += 1
            right -= 1

solution2 = Solution2()
string_list2 = ['p', 'a', 'n', 'd', 'a']
# Anropa metoden för att vända listan
solution2.reverseString2(string_list2)

# Skriv ut den omvända listan, vilket blir ['a', 'd', 'n', 'a', 'p']
print(string_list2)

# Slicing metod
# Klass som använder slicing för att vända listan
class Solution3:
    def reverseString3(self, s):
        # Använd slicing för att skapa en omvänd kopia av listan och tilldela den tillbaka till s
        s[:] = s[::-1]

solution3 = Solution3()
string_list3 = ['b', 'y', 'e']
# Anropa metoden för att vända listan
solution3.reverseString3(string_list3)

# Skriv ut den omvända listan, vilket blir ['e', 'y', 'b']
print(string_list3)