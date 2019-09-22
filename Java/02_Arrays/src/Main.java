public class Main {

    public static void main(String[] args) {
	// write your code here
        Array<Integer> newArray = new Array(20);

        for (int i =0; i < 10; i++){
            newArray.addLast(i);
        }
        System.out.println(newArray);

        newArray.addFirst(3);
        newArray.addFirst(3);
        newArray.add(2, 3);

        newArray.set(2, 4);

        System.out.println(newArray);

        newArray.removeLast();
        newArray.removeFirst();

        System.out.println(newArray);

        newArray.removeAllElement(100);




    }
}
