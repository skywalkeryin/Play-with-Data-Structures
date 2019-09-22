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


}
