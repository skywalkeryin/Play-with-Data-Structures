import javax.swing.plaf.synth.SynthTableUI;

public class Main {

    public static void main(String[] args) {
	// write your code here
        Array<Integer> newArray = new Array(12);

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
        newArray.removeFirst();
        newArray.removeFirst();

        System.out.println(newArray);


        newArray.addFirst(3);
        newArray.addFirst(3);
        newArray.addFirst(3);
        newArray.removeAllElement(3);

        System.out.println(newArray);


// test student
//        class Student{
//
//            private  String name;
//            private  int score;
//
//            public Student(String StudentName, int StudentScore){
//                this.name = StudentName;
//                this.score = StudentScore;
//            }
//
//            @Override
//            public String toString(){
//                return  String.format("Student name is %s, Score is %d.", name, score);
//            }
//        }
//
//
//        Array<Student> students = new Array<>(20);
//        students.addLast(new Student("san", 14));
//        students.addLast(new Student("san", 14));
//        students.addLast(new Student("san", 14));
//        System.out.println(students);


    }



}
