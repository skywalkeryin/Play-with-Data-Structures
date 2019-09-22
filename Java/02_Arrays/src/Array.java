public class Array {

    private int[] data;
    private int size;


    public Array(int capacity){
        data = new int[capacity];
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

    public int get(int index){
        if(index < 0 || index >= size ){
            throw new IllegalArgumentException("Illegal index argument.");
        }
        return  data[index];
    }

    // 修改index索引位置的元素为e
    public int set(int index, int e){
        if(index < 0 || index >= size ){
            throw new IllegalArgumentException("Illegal index argument.");
        }
        return  data[index] = e;
    }

    public boolean contains(int e){
        for (int i = 0; i < size; i++){
            if(data[i] == e){
                return  true;
            }
        }
        return  false;
    }
    // find array if contains element e, if not return -1.
    public int find(int e){
        for (int i = 0; i < size; i++){
            if(data[i] == e){
                return  i;
            }
        }
        return  -1;
    }

    // add an element at first position
    public void addFirst(int e){
        add(0, e);
    }

    // add an element at last position
    public void addLast(int e){
        add(size, e);
    }

    // add an
    public void add(int index, int e){

        if(size == data.length) {
            throw new IllegalArgumentException("Add failed. The array is full.");
        }

        //避免插入的元素造成数组的不连续
        if(index < 0 || index > size ){
           throw new IllegalArgumentException("Illegal index argument.");
        }

        for (int i = size - 1; i >= index; i--){
            data[i + 1] = data[i];
        }

        data[index] = e;
        size ++;
    }
    public int removeFirst(){
        return remove(0);
    }
    public int removeLast(){
        return remove(size - 1);
    }

    // 从数组删除元素e
    public void removeElement(int e){
        int index = find(e);
        if(index != -1) {
            remove(index);
        }
    }

    public void removeAllElement(int e){
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

    public int remove(int index){

        if(index < 0 || index >= size ){
            throw new IllegalArgumentException("Illegal index argument.");
        }
        int result = data[index];
        for(int i = index + 1; i < size; i++){
            data[i-1] = data[i];
        }
        size--;
        return result;
    }

    @Override
    public String toString(){

        StringBuilder sb = new StringBuilder();
        sb.append(String.format("Array: size=%d , capacity=%d\n", size, data.length));
        sb.append("[ ");
        for (int i = 0; i < size; i ++) {
            sb.append(data[i]);
            sb.append(", ");
        }
        sb.append("] ");
       return  sb.toString();
    }


}
