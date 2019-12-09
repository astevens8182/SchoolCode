
import javax.swing.*;
import java.awt.*;
import java.awt.image.*;
import javax.imageio.*;
import java.io.*;
/*** 
 * Alex Stevens
 * September 10, 2017
 * This is a class that desgins a busines card for my fictional business
 * 
 */
public class Drawing extends JPanel{

    public static void main() {
        JFrame f = new JFrame();
        f.setContentPane(new Drawing());
        f.setSize(600 , 400);
        f.setVisible(true);
    }

    public void paintComponent(Graphics g){
         int x= 0;
        int y = 0;
        // this statement required
        super.paintComponent(g);

        // optional: paint the background color (default is white)
        setBackground(Color.WHITE);

        // contact info
        Font myFont1 = new Font("sanserif", Font.BOLD,15);
        g.setFont(myFont1);
        g.drawString("Phone: 734-888-8888", 200,125);
        g.drawString("Email: Alexslawncare@gmail.com", 150, 150);
        g.drawString("Fax: 123-4567-8910", 200, 175);
        Font myFont = new Font("monospaced", Font.ITALIC,30);
        g.setFont(myFont);
        g.setColor(Color.black);
        g.drawString("Alex's Lawn Care", 150, 100);

        // draw a solid and empty rectangle

        g.setColor(Color.BLUE);
        g.drawRect(40, 60, 500, 300);

        // ovals on the side
        g.setColor(Color.BLUE);
        g.fillOval(x+50,y+ 70, 70, 50); 
        g.setColor(Color.GREEN);
        g.fillOval(x+50,y+ 140, 70, 50);
        g.setColor(Color.BLUE);
        g.fillOval(x+50,y+ 210, 70, 50); 
        g.setColor(Color.GREEN);
        g.fillOval(x+50,y+ 280, 70, 50); 

        // box at the bottom
        g.fillRect(x+130,y+ 298, 400, 20); 

        // picture logo
        BufferedImage photo = null;
        try {
            File file = new File("face1.jpg");
            photo = ImageIO.read(file);
        }       catch (IOException e){

        }
        g.drawImage(photo, 250, 180, 80, 115, null);

    }
}
