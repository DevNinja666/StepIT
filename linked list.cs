template<typename T>
struct Node {
    T data;
    Node* next;
    Node* prev;
    Node(const T& d) : data(d), next(nullptr), prev(nullptr) {}
};

template<typename T>
class LinkedListIterator {
private:
    Node<T>* ptr;
public:
    LinkedListIterator(Node<T>* p = nullptr) : ptr(p) {}

    T& operator*() { return ptr->data; }
    T* operator->() { return &(ptr->data); }

    bool operator==(const LinkedListIterator& other) const { return ptr == other.ptr; }
    bool operator!=(const LinkedListIterator& other) const { return ptr != other.ptr; }

    LinkedListIterator& operator++() {
        if (ptr) ptr = ptr->next;
        return *this;
    }

    LinkedListIterator operator++(int) {
        LinkedListIterator temp = *this;
        if (ptr) ptr = ptr->next;
        return temp;
    }

    LinkedListIterator& operator--() {
        if (ptr) ptr = ptr->prev;
        return *this;
    }

    LinkedListIterator operator--(int) {
        LinkedListIterator temp = *this;
        if (ptr) ptr = ptr->prev;
        return temp;
    }

    LinkedListIterator operator+(int n) const {
        LinkedListIterator temp = *this;
        while (n-- > 0 && temp.ptr) temp.ptr = temp.ptr->next;
        return temp;
    }

    LinkedListIterator operator-(int n) const {
        LinkedListIterator temp = *this;
        while (n-- > 0 && temp.ptr) temp.ptr = temp.ptr->prev;
        return temp;
    }

    LinkedListIterator operator-() const {
        return LinkedListIterator(ptr ? ptr->prev : nullptr);
    }
};
