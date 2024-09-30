package DarrenIsLearningJava;

import java.awt.Point;

public class Circle {
    Point centre;
    private double radius;
    private static int nubmerOfCircles;
    
    Circle ()
    {
        nubmerOfCircles++;
        centre = new Point(1,1);
        radius = 1;
    }

    Circle (Point initialPoint, double initialRadius){
        nubmerOfCircles++;
        this.centre = initialPoint;
        this.radius = initialRadius;
    }

    double getPerimeter(){
        return 2 * Math.PI * radius;
    }

    double getArea(){
        return 2 * Math.PI * radius * radius;
    }

    void setRadius(double newRadius){
        radius = newRadius;
    }

    void setCentre(Point newCentre){
        centre = newCentre;
    }

    public static int getCircleCount(){
        return nubmerOfCircles;
    }

    int getCircleCountObject(){
        return nubmerOfCircles;
    }


    
}
