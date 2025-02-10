# Definition av en enkel nod i en länkad lista
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val  # Värdet som noden håller
        self.next = next  # Pekaren till nästa nod


# En enkel implementation av en länkad lista
class LinkedList:
    def __init__(self):
        self.head = None  # Startpunkten av listan

    # Metod för att lägga till en nod i slutet av listan
    def append(self, value):
        new_node = ListNode(value)  # Skapa en ny nod
        if not self.head:  # Om listan är tom, gör den nya noden till head
            self.head = new_node
            return
        current = self.head
        while current.next:  # Gå till slutet av listan
            current = current.next
        current.next = new_node  # Lägg till den nya noden i slutet

    # Metod för att skriva ut listan
    def print_list(self):
        current = self.head
        while current:
            print(current.val, end=" -> ")
            current = current.next
        print("None")


# Lösningsklassen som hanterar sammanslagningen av två länkade listor
class Solution:
    def mergeTwoLists(self, list1, list2):
        merged_head = ListNode()  # Skapa en dummy nod som startpunkt
        current_node = merged_head  # Pekare som bygger den nya listan
        
        # Loopar igenom båda listorna så länge de båda har noder kvar
        while list1 and list2:
            if list1.val <= list2.val:
                current_node.next = list1  # Lägg till list1:s nod
                list1 = list1.next  # Gå till nästa nod i list1
            else:
                current_node.next = list2  # Lägg till list2:s nod
                list2 = list2.next  # Gå till nästa nod i list2
            current_node = current_node.next  # Flytta pekaren i den nya listan
        
        # Lägg till kvarvarande noder
        current_node.next = list1 if list1 else list2
        
        # Returnera den sammanslagna listan, utan dummy noden
        return merged_head.next


# Exempel på hur du kan använda klasserna
list1 = LinkedList()
list1.append(1)
list1.append(3)
list1.append(4)

list2 = LinkedList()
list2.append(1)
list2.append(2)
list2.append(5)

# Skriv ut de två ursprungliga listorna
print("List 1:")
list1.print_list()

print("List 2:")
list2.print_list()

# Slå samman listorna
solution = Solution()
merged_list_head = solution.mergeTwoLists(list1.head, list2.head)

# Skriv ut den sammanslagna listan
print("Merged List:")
merged_list = LinkedList()
merged_list.head = merged_list_head
merged_list.print_list()