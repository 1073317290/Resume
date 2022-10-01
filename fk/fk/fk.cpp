#include <stdio.h>
#include <graphics.h>
#include <cstdlib>
#include <ctime>
#include <time.h>
#include "box.h"
#include <conio.h>


int main() {
	initgraph(Window_Width, Window_Height);
	initGame();
	int count = 0;
	int leval = 100;
	int goal = 0;
	bool gameover = false;
	srand((int)time(0));//随机数种子
	int style = random(7);
	int direction = random(3);
	while (!gameover) {
		count += 1;
		Boxs box(style, direction);
		style = random(7);
		direction = random(3);
		box.tip(style, direction);
		bool flag0 = true;
		while (flag0) {
			box.draw();
			Sleep(leval);
			flag0 = box.move_vertical();
			while (_kbhit()) {
				char ch = 0;
				ch = _getch();
				switch (ch)
				{
				case 72://上
					box.rotate();
					box.draw();
					break;
				case 75://左
					box.move_left();
					box.draw();
					break;
				case 77://右
					box.move_right();
					box.draw();
					break;
				case 80: //下
					box.move_vertical();
					box.draw();
					break;
				case 32: //空格
					for (int i = 24; i > 0; i--) {
						box.move_vertical();
					}
					flag0 = false;
					box.draw();
					break;
				default:
					break;
				}
			}
			box.draw();
		}
		gameover = box.check();
	}
	closegraph();
	return 0;
}


