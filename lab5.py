"""Выполнил Избасаров Диас
7. Ленивый Поиск в Ширину (Breadth-First Search)
- Реализовать ленивый алгоритм поиска в ширину для графа или дерева.
"""


class TreeNode:
    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None


def construct_tree():
    n = int(input("Введите количество уровней дерева: "))
    if n <= 0:
        return None

    root_val = int(input("Введите значение корневого узла: "))
    root = TreeNode(root_val)
    queue = [root]

    for _ in range(n):
        level_length = len(queue)
        for _ in range(level_length):
            current = queue.pop(0)

            left_val = int(input(f"Введите значение левого потомка для {current.val}: "))
            if left_val != -1:  # -1 будет означать отсутствие потомка
                current.left = TreeNode(left_val)
                queue.append(current.left)

            right_val = int(input(f"Введите значение правого потомка для {current.val}: "))
            if right_val != -1:  # -1 будет означать отсутствие потомка
                current.right = TreeNode(right_val)
                queue.append(current.right)

    return root


def bfs_tree_lazy(root):
    if not root:
        return

    queue = [root]  # Initialize a deque with the root node

    while queue:  # While the deque is not empty
        current = queue.pop()  # Dequeue the current node
        yield current.val  # Yield the value of the current node

        # Enqueue the left and right children if they exist
        if current.left:
            queue.append(current.left)
        if current.right:
            queue.append(current.right)


root = construct_tree()

"""
root = TreeNode(3)
root.right = TreeNode(2)
root.left = TreeNode(4)
root.left.left = TreeNode(1)
root.left.right = TreeNode(3)
"""
for node_val in bfs_tree_lazy(root):
    print(node_val, end=' ')
