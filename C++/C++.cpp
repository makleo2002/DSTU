#include <cmath>
#include <GL/freeglut.h>
#include "SOIL.h" 
#include <iostream>
using namespace std;

GLuint hatTexture;

float angle = 0.0;
float lx = 0.0f, lz = -1.0f;
float x = 0.0f, z = 5.0f;

float headRotationAngle = 0.0f;

void createLightning(GLfloat ambient[], GLfloat diffuse[], GLfloat specular[], GLfloat shininess) {
    glMaterialfv(GL_FRONT, GL_AMBIENT, ambient);
    glMaterialfv(GL_FRONT, GL_DIFFUSE, diffuse);
    glMaterialfv(GL_FRONT, GL_SPECULAR, specular);
    glMaterialf(GL_FRONT, GL_SHININESS, shininess);
}

void loadTexture(const char* filename) {

    hatTexture = SOIL_load_OGL_texture(
        filename,
        SOIL_LOAD_AUTO,
        SOIL_CREATE_NEW_ID,
        SOIL_FLAG_INVERT_Y
    );

    if (!hatTexture) {
       cout<<"Error loading texture: \n";
       cout << SOIL_last_result();
    }
}


void drawSnowman() {

    GLfloat shininess = 100.0f;

    GLfloat snowman_ambient[] = { 0.0f, 0.0f, 1.0f, 1.0f };
    GLfloat snowman_diffuse[] = { 0.0f, 0.0f, 1.0f, 1.0f };
    GLfloat snowman_specular[] = { 1.0f, 1.0f, 1.0f, 1.0f };

    GLfloat eye_ambient[] = { 1.0f, 1.0f, 1.0f, 1.0f };
    GLfloat eye_diffuse[] = { 1.0f, 1.0f, 1.0f, 1.0f };
    GLfloat eye_specular[] = { 1.0f, 1.0f, 1.0f, 1.0f };

    GLfloat nose_ambient[] = { 1.0f, 0.5f, 0.0f, 1.0f };
    GLfloat nose_diffuse[] = { 1.0f, 0.5f, 0.0f, 1.0f };
    GLfloat nose_specular[] = { 1.0f, 0.5f, 0.0f, 1.0f };

    GLfloat hat_ambient[] = { 0.6f, 0.3f, 0.0f, 1.0f };
    GLfloat hat_diffuse[] = { 0.6f, 0.3f, 0.0f, 1.0f };
    GLfloat hat_specular[] = { 1.0f, 1.0f, 1.0f, 1.0f };

    // Нижняя часть тела 
    glColor3f(0.0f, 0.0f, 1.0f);
    createLightning(snowman_ambient, snowman_diffuse, snowman_specular, shininess);
    glTranslatef(0.0f, 0.75f, 0.0f);
    glutSolidSphere(0.75f, 20, 20);

    

    // Верхняя часть тела 
    glColor3f(0.0f, 0.0f, 1.0f);
    glTranslatef(0.0f, 1.0f, 0.0f);
    glutSolidSphere(0.5f, 20, 20);

    // Голова
    glColor3f(0.0f, 0.0f, 1.0f);
    glTranslatef(0.0f, 0.8f, 0.0f);
    glRotatef(headRotationAngle, 0.0f, 1.0f, 0.0f);  
    glutSolidSphere(0.3f, 20, 20);

    // Левый глаз
    glPushMatrix();
    glColor3f(1.0f, 1.0f, 1.0f);
    createLightning(eye_ambient, eye_diffuse, eye_specular, shininess);
    glTranslatef(-0.15f, 0.1f, 0.25f);
    glutSolidSphere(0.05f, 10, 10);
    glPopMatrix();

    // Правый глаз
    glPushMatrix();
    glColor3f(1.0f, 1.0f, 1.0f);    
    createLightning(eye_ambient, eye_diffuse, eye_specular, shininess);
    glTranslatef(0.15f, 0.1f, 0.25f);
    glutSolidSphere(0.05f, 10, 10);
    glPopMatrix();
  
    // Нос 
    glPushMatrix();
    glColor3f(1.0f, 0.5f, 0.0f);
    createLightning(nose_ambient, nose_diffuse, nose_specular, shininess);
    glTranslatef(0.0f, -0.05f, 0.2f);
    glutSolidCone(0.1f, 0.5f, 10, 2);
    glPopMatrix();

    // Шляпа
    glPushMatrix();
    glEnable(GL_TEXTURE_2D);
    glBindTexture(GL_TEXTURE_2D, hatTexture);
    glColor3f(0.6f, 0.3f, 0.0f);
    createLightning(hat_ambient, hat_diffuse, hat_specular, shininess);
    glTranslatef(0.0f, 0.4f, 0.0f);
    glScalef(0.5f, 0.2f, 0.3f);
    glutSolidCube(1.0f);
    glDisable(GL_TEXTURE_2D);
    glPopMatrix();

    //Пуговица
    glPushMatrix();
    glColor3f(1.0f, 1.0f, 1.0f);
    glTranslatef(0.0f, -0.6f, 0.5f);
    glutSolidSphere(0.05f, 10, 10);
    glPopMatrix();

    //Пуговица
    glPushMatrix();
    glColor3f(1.0f, 1.0f, 1.0f);
    glTranslatef(0.0f, -0.9f, 0.55f);
    glutSolidSphere(0.05f, 10, 10);
    glPopMatrix();

    //Пуговица
    glPushMatrix();
    glColor3f(1.0f, 1.0f, 1.0f);
    glTranslatef(0.0f, -1.4f, 0.7f);
    glutSolidSphere(0.05f, 10, 10);
    glPopMatrix();

    //Пуговица
    glPushMatrix();
    glColor3f(1.0f, 1.0f, 1.0f);
    glTranslatef(0.0f, -1.7f, 0.8f);
    glutSolidSphere(0.05f, 10, 10);
    glPopMatrix();

    //Пуговица
    glPushMatrix();
    glColor3f(1.0f, 1.0f, 1.0f);
    glTranslatef(0.0f, -2.0f, 0.8f);
    glutSolidSphere(0.05f, 10, 10);
    glPopMatrix();

}

void renderScene(void) {
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    glLoadIdentity();
    gluLookAt(x, 1.0f, z, x + lx, 1.0f, z + lz, 0.0f, 1.0f, 0.0f);

    // Земля
    glColor3f(0.9f, 0.9f, 0.9f);

    GLfloat ground_ambient[] = { 0.9f, 0.9f, 0.9f, 1.0f };
    GLfloat ground_diffuse[] = { 0.9f, 0.9f, 0.9f, 1.0f };
    GLfloat ground_specular[] = { 0.0f, 0.0f, 0.0f, 1.0f }; 
    GLfloat ground_shininess = 0.0f; 
    createLightning(ground_ambient, ground_diffuse, ground_specular, ground_shininess);

    glBegin(GL_QUADS);
    glVertex3f(-100.0f, 0.0f, -100.0f);
    glVertex3f(-100.0f, 0.0f, 100.0f);
    glVertex3f(100.0f, 0.0f, 100.0f);
    glVertex3f(100.0f, 0.0f, -100.0f);
    glEnd();

    //headRotationAngle += 0.3f;

    // Снеговик
    glPushMatrix();
    drawSnowman();
    glPopMatrix();

    glutSwapBuffers();
}

void changeSize(int w, int h) {
    if (h == 0) h = 1;

    double ratio = 1.0 * w / h;

    glMatrixMode(GL_PROJECTION); 
    glLoadIdentity();//единичная матрица проекции

    glViewport(0, 0, w, h);//весь экран

    gluPerspective(45, ratio, 1, 1000);
    glMatrixMode(GL_MODELVIEW);
}

void escape(unsigned char key, int xx, int yy) {
    if (key == 27)
        exit(0);
}

void processSpecialKeys(int key, int xx, int yy) {
    float fraction = 0.2f;//величина перемещения
    switch (key) {
    case GLUT_KEY_LEFT:
        angle -= 0.01f;
        lx = sin(angle);
        lz = -cos(angle);
        break;
    case GLUT_KEY_RIGHT:
        angle += 0.01f;
        lx = sin(angle);
        lz = -cos(angle);
        break;
    case GLUT_KEY_UP:
        x += lx * fraction;
        z += lz * fraction;
        break;
    case GLUT_KEY_DOWN:
        x -= lx * fraction;
        z -= lz * fraction;
        break;
    }
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGBA);
    glutInitWindowPosition(100, 100);
    glutInitWindowSize(800, 600);
    glutCreateWindow("OpenGL Snowman");

    loadTexture("C:/img/texture2.jpg");

    glEnable(GL_LIGHTING);//рассчет освещения
    glEnable(GL_LIGHT0);//первый источник света

    GLfloat light_position[] = { 1.0f, 1.0f, 1.0f, 0.0f };  
    GLfloat light_ambient[] = { 0.2f, 0.2f, 0.2f, 1.0f };
    GLfloat light_diffuse[] = { 1.0f, 1.0f, 1.0f, 1.0f };
    GLfloat light_specular[] = { 1.0f, 1.0f, 1.0f, 1.0f };

    glLightfv(GL_LIGHT0, GL_POSITION, light_position);
    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);
    glLightfv(GL_LIGHT0, GL_DIFFUSE, light_diffuse);
    glLightfv(GL_LIGHT0, GL_SPECULAR, light_specular);

    glutDisplayFunc(renderScene);//сцена
    glutReshapeFunc(changeSize);//окно
    glutIdleFunc(renderScene);//простой
    glutKeyboardFunc(escape);//выход
    glutSpecialFunc(processSpecialKeys);//движение камеры

    glEnable(GL_DEPTH_TEST);//вкл тест глубины

    glutMainLoop();//беск. цикл обработки событий

    return 0;
}


/*
1 лаба(2д снеговик):
#include <GL/freeglut.h>
#include <cmath>
void drawCircle(float radius, int segments) {
    glBegin(GL_TRIANGLE_FAN); //triangle stripes
    for (int i = 0; i < segments; i++) {
        float theta = 2.0f * 3.1415926f * float(i) / float(segments);
        float x = radius * std::cos(theta);
        float y = radius * std::sin(theta);
        glVertex2f(x, y);
    }
    glEnd();
}

void drawSnowman() {
    glClearColor(1.0, 1.0, 1.0, 1.0); // меняем цвет фона на белый
    glClear(GL_COLOR_BUFFER_BIT);

    // нижний круг
    glColor3f(0.0, 0.0, 1.0);
    glPushMatrix();
    glTranslatef(0.0, -0.2, 0.0);
    drawCircle(0.2, 30);
    glPopMatrix();

    // средний круг
    glPushMatrix();
    glTranslatef(0.0, 0.1, 0.0);
    drawCircle(0.15, 30);
    glPopMatrix();

    // верхний круг
    glPushMatrix();
    glTranslatef(0.0, 0.3, 0.0);
    drawCircle(0.1, 30);
    glPopMatrix();

    // глаза
    glColor3f(1.0, 1.0, 1.0);
    glPushMatrix();
    glTranslatef(-0.05, 0.35, 0.1);
    drawCircle(0.015, 30);  // левый глаз
    glTranslatef(0.1, 0.0, 0.0);
    drawCircle(0.015, 30);  // правый глаз
    glPopMatrix();

    // нос
    glColor3f(1.0, 0.5, 0.0);
    glPushMatrix();
    glTranslatef(0.0, 0.3, 0.1);
    glutSolidCone(0.02, 0.1, 30, 30);  // конус
    glPopMatrix();

    // шляпа
    glColor3f(0.6, 0.3, 0.0);
    glPushMatrix();
    glTranslatef(0.0, 0.44, 0.0);
    glScalef(0.2, 0.1, 1.0);
    glutSolidCube(1.0);  // коричневый прямоугольник
    glPopMatrix();

    glFlush();
}
int main(int argc, char** argv) {

    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
    glutInitWindowSize(800, 600);
    glutCreateWindow("OpenGL Snowman");

    glutDisplayFunc(drawSnowman);
    glutMainLoop();

    return 0;

}
*/