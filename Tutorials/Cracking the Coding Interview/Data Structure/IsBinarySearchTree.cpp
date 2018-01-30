/*
Trees: Is This a Binary Search Tree?
https://www.hackerrank.com/challenges/ctci-is-binary-search-tree/problem
*/
/* Hidden stub code will pass a root argument to the function below. Complete the function to solve the challenge. Hint: you may want to write one or more helper functions.  

The Node struct is defined as follows:
   struct Node {
      int data;
      Node* left;
      Node* right;
   }
*/
bool checkBST(Node* root)
{
    return checkSubTreeWithBoundary(root, INT32_MIN, INT32_MAX);
}
bool checkSubTreeWithBoundary(Node *node, int leftBoundary, int rightBoundary)
{
    if(node == NULL)
        return true;
    if(!isInInterval(node->data, leftBoundary, rightBoundary))
        return false;
    return checkSubTreeWithBoundary(node->left, leftBoundary, node->data) &&
        checkSubTreeWithBoundary(node->right, node->data, rightBoundary);
}
bool isInInterval(int value, int leftBoundary, int rightBoundary)
{
    return leftBoundary < value && value < rightBoundary;
}
