using System;
using System.Text;

public class MyArray<T>{

    private T[] data;
    private int size;

    public MyArray(int capacity){
        data = new T[capacity];
        size = 0;
    }

    public MyArray() : this(10){
        
    }
     
    public bool IsEmpty(){
        return size == 0;
    }

    public int GetSize(){
        return data.Length;
    }

    public void AddFirst(T e){
      add(0, e);
    }

    public void AddLast(T e){
      add(size, e);
    }

    private void add(int index, T e){

        if(index < 0 || index > size){
            throw new ArgumentException("Illegal Argument.", "index");
        }

        // the array is full
        if(size == data.Length){
            resize( 2 * data.Length );
        }
        // from backward to forward
        for(int i = size - 1; i >= index; i--){
            data[i + 1] = data[i];
        }
        
        data[index] = e;
        size ++;
    }

    // check element if contains in an array
    public bool Contains(T e){
        for(int i = 0; i < data.Length; i++){
            if(data[i].Equals(e)){
               return true;
            }
        }
        return false;
    }
    
    // find the element in array, return index otherwise return -1
    public int Find(T e){
        for(int i = 0; i < data.Length; i++){
            if(data[i].Equals(e)){
               return i;
            }
        }
        return -1;
    }

    public T RemoveFirst(){
        return remove(0);
    }

    public T RemoveLast(){
        return remove(size - 1);
    }

    private T remove(int index){

         if(index < 0 || index >= size){
             throw new ArgumentNullException("Illegar argment.");
         }

         T result = data[index];
         for(int i = index; i < size - 1; i++ )
         {
             data[i] = data[i + 1];
         }
         size--;
         data[size] = default(T);

        if(size == data.Length / 4 && data.Length / 2 != 0){
            resize(data.Length / 2);
         }

         return result;

    }

    public override string ToString(){
          StringBuilder sb =new StringBuilder();
          sb.Append(String.Format("Array size is {0}, capacity is {1}. \n", size, data.Length));
          sb.Append(" [ ");
          for(int i = 0; i < size; i++){
              sb.Append(data[i]);
              sb.Append(", ");
          }
          sb.Append("] ");
          return sb.ToString();
    }

    private void resize(int newCapacity){

       T[] newData = new T[newCapacity];
       for(int i = 0; i < data.Length; i++){
         newData[i] = data[i];
       }
       data = newData;
    }

}
