/*
Detect a cycle in a linked list. Note that the head pointer may be 'NULL' if the list is empty.

A Node is defined as: 
    struct Node {
        int data;
        struct Node* next;
    }
*/
bool has_cycle(Node* head) {
    // Complete this function
    // Do not write the main method
    const int LIMIT = 100;
    Node *notNullPointer=head, *visitingPointer;
    int depth = 0, visitingDepth;
    while(notNullPointer!=NULL && (depth++)<LIMIT)
    {
        visitingPointer = notNullPointer->next;
        visitingDepth = depth;
        while(visitingPointer!=NULL && (visitingDepth++)<LIMIT)
        {
            if(visitingPointer==notNullPointer)
                return true;
            visitingPointer = visitingPointer->next;
        }
        notNullPointer = notNullPointer->next;
    }
    return false;
}
