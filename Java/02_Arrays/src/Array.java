public class Array<T> {

    private T[] data;
    private int size;


    public Array(int capacity){
        data = (T[])new Object[capacity];
        size = 0;
    }

    public Array(){

        this(10);
    }

    public boolean isEmpty(){
        return size == 0;
    }

    public int getSize(){

        return size;
    }
    
    public int getCapacity(){

        return  data.length;
    }

    public T get(int index){
        if(index < 0 || index >= size ){
            throw new IllegalArgumentException("Illegal index argument.");
        }
        return  data[index];
    }

    // 修改index索引位置的元素为e
    public void set(int index, T e){
        if(index < 0 || index >= size ){
            throw new IllegalArgumentException("Illegal index argument.");
        }
        data[index] = e;
    }

    public boolean contains(T e){
        for (int i = 0; i < size; i++){
            if(data[i].equals(e)){
                return  true;
            }
        }
        return  false;
    }
    // find array if contains element e, if not return -1.
    public int find(T e){
        for (int i = 0; i < size; i++){
            if(data[i].equals(e)){
                return  i;
            }
        }
        return  -1;
    }

    // add an element at first position
    public void addFirst(T e){
        add(0, e);
    }

    // add an element at last position
    public void addLast(T e){
        add(size, e);
    }

    // add an
    public void add(int index, T e){

        //避免插入的元素造成数组的不连续
        if(index < 0 || index > size ){
           throw new IllegalArgumentException("Illegal index argument.");
        }

        if(size == data.length) {
            resize(data.length * 2 );
            //throw new IllegalArgumentException("Add failed. The array is full.");
        }


        for (int i = size - 1; i >= index; i--){
            data[i + 1] = data[i];
        }

        data[index] = e;
        size ++;
    }
    public T removeFirst(){
        return remove(0);
    }
    public T removeLast(){
        return remove(size - 1);
    }

    // 从数组删除元素e
    public void removeElement(T e){
        int index = find(e);
        if(index != -1) {
            remove(index);
        }
    }

    public void removeAllElement(T e){
        int index = find(e);
        if(index != -1) {
            for(int i = 0; i < size; i++){
                if(data[i] == e){
                    remove(i);
                }
            }
        }else{
            System.out.println("There is no " + e + " in the array");

           // throw new IllegalArgumentException("There is no this element in the array");
        }
    }

    public T remove(int index){

        if(index < 0 || index >= size ){
            throw new IllegalArgumentException("Illegal index argument.");
        }
        T result = data[index];
        for(int i = index + 1; i < size; i++){
            data[i-1] = data[i];
        }
        size--;
        data[size] = null; // loitering objects
        if(size == data.length / 2)
        {
            resize( data.length / 2);
        }
        return result;
    }

    @Override
    public String toString(){

        StringBuilder sb = new StringBuilder();
        sb.append(String.format("Array: size=%d , capacity=%d\n", size, data.length));
        sb.append("[ ");
        for (int i = 0; i < size; i ++) {
            sb.append(data[i].toString());
            sb.append(", ");
        }
        sb.append("] ");
       return  sb.toString();
    }

    private void resize(int newCapacity) {
        T[] newData = (T[]) new Object[newCapacity];

        for(int i = 0; i < size; i++){
            newData[i] = data[i];
        }
        data = newData;
    }



}
