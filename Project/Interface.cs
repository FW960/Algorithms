using LinkedListNode;
using System;

namespace NodesInterface
{
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value); // добавляет новый элемент списка
        void AddNodeAfter(LinkedListNode.Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(LinkedListNode.Node node); // удаляет указанный элемент
        LinkedListNode.Node FindNode(int searchValue); // ищет элемент по его значению
    }
}

