#include <iostream>
#include <stdio.h>
#include <graphics.h>
#include <cstdlib>

#define Window_Width 600
#define Window_Height 750
#define Block_Length 30
#define GameRegion_CellNumber_Width 12
#define GameRegion_CellNumber_Height 24
#define GameRegion_BorderLength 10 //边框距离
//#define Goal 0

#define random(x) rand()%(x) //取随机

//#define Map[GameRegion_CellNumber_Height][GameRegion_CellNumber_Width]={0};

int leval = 1000;
int goal = 0;
char text1[25];
int Map[GameRegion_CellNumber_Height][GameRegion_CellNumber_Width];



void initGame();
void ResetGameArea();

class Boxs
{
public:
	//Boxs();
	Boxs(unsigned const int style, unsigned const int direction);
	~Boxs();
	void draw();
	bool move_vertical();
	void move_left();
	void move_right();
	void rotate();
	bool check();
	void tip(int style, int direction);

private:
	bool Moveable_vertical;
	bool Moveable_left;
	bool Moveable_right;
	int Style;
	int color;
	int Direction;
	//int Count;
	//int Map[GameRegion_CellNumber_Height][GameRegion_CellNumber_Width];
};




Boxs::Boxs(unsigned const int style, unsigned const int direction)
{
	Moveable_vertical = true;
	Moveable_left = true;
	Moveable_right = true;
	//srand((int)time(0));//随机数种子
	Style = style;
	Direction = direction;
	/*Style = random(7);
	Direction = random(3);*/
	for (int i = 0; i != GameRegion_CellNumber_Height; i++) {       //初始化map
		for (int j = 0; j != GameRegion_CellNumber_Width; j++) {
			if (Map[i][j] != 1 && Map[i][j] != 2) {
				Map[i][j] = 0;
			}
			else {
				Map[i][j] = 2;
			}
		}
	}
	switch (Boxs::Style)
	{
	case 0:
		color = RED;
		Map[0][4] = 1;
		Map[0][5] = 1;
		Map[0][6] = 1;
		Map[0][7] = 1;
		break;
	case 1:
		color = GREEN;
		Map[0][6] = 1;
		Map[1][5] = 1;
		Map[1][6] = 1;
		Map[1][7] = 1;
		break;
	case 2:
		color = BROWN;
		Map[0][5] = 1;
		Map[1][5] = 1;
		Map[1][6] = 1;
		Map[1][7] = 1;
		break;
	case 3:
		color = BLUE;
		Map[0][7] = 1;
		Map[1][5] = 1;
		Map[1][6] = 1;
		Map[1][7] = 1;
		break;
	case 4:
		color = 0xFF3EE9;
		Map[0][6] = 1;
		Map[0][7] = 1;
		Map[1][5] = 1;
		Map[1][6] = 1;
		break;
	case 5:
		color = 0xEEF037;
		Map[0][4] = 1;
		Map[0][5] = 1;
		Map[1][5] = 1;
		Map[1][6] = 1;
		break;
	case 6:
		color = 0xFFA500;
		Map[0][5] = 1;
		Map[0][6] = 1;
		Map[1][5] = 1;
		Map[1][6] = 1;
		break;
	default:
		color = 0x000000;
		break;
	}
	for (int i = Direction; i != 0; i--) {
		rotate();
	}

}

Boxs::~Boxs()
{
}

void Boxs::draw() {
	ResetGameArea();
	//ResetGameArea();
	for (int i = 0; i != GameRegion_CellNumber_Height; i++) {
		for (int j = 0; j != GameRegion_CellNumber_Width; j++) {
			if (Map[i][j] == 1) {
				setfillcolor(color);
				fillrectangle(j * Block_Length + GameRegion_BorderLength,
					i * Block_Length + Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height,
					j * Block_Length + GameRegion_BorderLength + Block_Length,
					i * Block_Length + Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height + Block_Length);
			}
			else if (Map[i][j] == 2) {
				setfillcolor(RGB(52, 180, 201));
				fillrectangle(j * Block_Length + GameRegion_BorderLength,
					i * Block_Length + Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height,
					j * Block_Length + GameRegion_BorderLength + Block_Length,
					i * Block_Length + Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height + Block_Length);
			}
		}
	}
}

bool Boxs::move_vertical() {
	for (int x = 0; x != GameRegion_CellNumber_Width; x++) {
		if (Map[23][x] == 1) {
			Moveable_vertical = false;
		}
	}
	for (int i = GameRegion_CellNumber_Height - 2; i != -1; i--) {      //22到0
		for (int j = 0; j != GameRegion_CellNumber_Width; j++) {   //0到11
			if (Map[i][j] == 1) {
				if (Map[i + 1][j] == 2) {
					Moveable_vertical = false;
				}
			}
		}
	}
	if (Moveable_vertical) {
		for (int i = GameRegion_CellNumber_Height - 2; i != -1; i--) {      //22到0
			for (int j = 0; j != GameRegion_CellNumber_Width; j++) {   //0到11
				if (Map[i][j] == 1) {
					Map[i + 1][j] = 1;
					Map[i][j] = 0;
				}
			}
		}
		return true;
	}
	else {
		for (int i = 0; i != GameRegion_CellNumber_Height; i++) {
			for (int j = 0; j != GameRegion_CellNumber_Width; j++) {
				if (Map[i][j] == 1) {
					Map[i][j] = 2;
				}
			}
		}
		return false;
	}
}

void Boxs::move_left() {
	Moveable_right = true;
	Moveable_left = true;
	for (int i = 0; i != GameRegion_CellNumber_Height; i++) {      //0到23
		if (Map[i][0] == 1)
			Moveable_left = false;
		for (int j = 1; j != GameRegion_CellNumber_Width; j++) {   //1到11
			if (Map[i][j] == 1) {
				if (Map[i][j - 1] == 2) {
					Moveable_left = false;
				}
			}
		}
	}
	if (Moveable_left) {
		for (int i = 0; i != GameRegion_CellNumber_Height; i++) {      //0到23
			for (int j = 1; j != GameRegion_CellNumber_Width; j++) {   //1到11
				if (Map[i][j] == 1 && Map[i][j - 1] == 0) {
					Map[i][j - 1] = 1;
					Map[i][j] = 0;
				}
			}
		}
	}
}

void Boxs::move_right() {
	Moveable_right = true;
	Moveable_left = true;
	for (int i = 0; i != GameRegion_CellNumber_Height; i++) {      //0到23
		if (Map[i][11] == 1)
			Moveable_right = false;
		for (int j = GameRegion_CellNumber_Width - 2; j != -1; j--) {   //10到0
			if (Map[i][j] == 1) {
				if (Map[i][j + 1] == 2) {
					Moveable_right = false;
				}
			}
		}
	}
	if (Moveable_right) {
		for (int i = 0; i != GameRegion_CellNumber_Height; i++) {      //0到23
			for (int j = GameRegion_CellNumber_Width - 2; j != -1; j--) {   //10到0
				if (Map[i][j] == 1) {
					Map[i][j + 1] = 1;
					Map[i][j] = 0;
				}
			}
		}
	}
}

void  Boxs::rotate() {
	bool overloop = false;
	switch (Style)
	{
	case 0:
		for (int i = 0; i != GameRegion_CellNumber_Height - 2; i++) { //1~21
			for (int j = 0; j != GameRegion_CellNumber_Width - 2; j++) { //0-9
				if (Map[i][j] == 1) {
					if (Map[i][j + 1] == 1 && j < 9) {					//0
						if (Map[i + 1][j + 1] == 0 && Map[i + 2][j + 1] == 0 && Map[i + 3][j + 1] == 0) {
							Map[i + 1][j + 1] = 1; Map[i + 2][j + 1] = 1; Map[i + 3][j + 1] = 1;
							Map[i][j] = 0; Map[i][j + 2] = 0; Map[i][j + 3] = 0;
							overloop = true;
						}
					}
					else if (Map[i + 1][j] == 1 && j != 0) {				//1
						if (Map[i][j - 1] == 0 && Map[i][j + 1] == 0 && Map[i][j + 2] == 0) {
							Map[i][j - 1] = 1; Map[i][j + 1] = 1; Map[i][j + 2] = 1;
							Map[i + 1][j] = 0; Map[i + 2][j] = 0; Map[i + 3][j] = 0;
							overloop = true;

						}
					}
				}
				if (overloop == true)
					break;
			}
			if (overloop == true)
				break;
		}
		break;
	case 1:
		for (int i = 1; i != GameRegion_CellNumber_Height - 2; i++) { //1~21
			for (int j = 1; j != GameRegion_CellNumber_Width - 1; j++) { //0-1
				if (Map[i][j] == 1) {
					if (Map[i][j - 1] == 1 && Map[i][j + 1] == 1 && Map[i - 1][j] == 1) {					//0
						if (Map[i + 1][j] == 0) {
							Map[i + 1][j] = 1;
							Map[i][j - 1] = 0;
							overloop = true;
						}
					}
					else if (Map[i + 1][j] == 1 && Map[i][j + 1] == 1 && Map[i - 1][j] == 1) {				//1
						if (Map[i][j - 1] == 0) {
							Map[i][j - 1] = 1;
							Map[i - 1][j] = 0;
							overloop = true;
						}
					}
					else if (Map[i + 1][j] == 1 && Map[i][j + 1] == 1 && Map[i][j - 1] == 1) {				//2
						if (Map[i - 1][j] == 0) {
							Map[i - 1][j] = 1;
							Map[i][j + 1] = 0;
							overloop = true;
						}
					}
					else if (Map[i + 1][j] == 1 && Map[i - 1][j] == 1 && Map[i][j - 1] == 1) {				//3
						if (Map[i][j + 1] == 0) {
							Map[i][j + 1] = 1;
							Map[i + 1][j] = 0;
							overloop = true;
						}
					}
				}
				if (overloop == true)
					break;
			}
			if (overloop == true)
				break;
		}
		break;
	case 2:
		for (int i = 1; i != GameRegion_CellNumber_Height - 2; i++) { //1~21
			for (int j = 0; j != GameRegion_CellNumber_Width; j++) {
				if (Map[i][j] == 1) {
					if (Map[i + 1][j] == 1 && Map[i + 1][j + 1] == 1) {//0
						if (Map[i][j + 1] == 0 && Map[i][j + 2] == 0 && Map[i + 2][j + 1] == 0) {
							Map[i][j + 1] = 1; Map[i][j + 2] = 1; Map[i + 2][j + 1] = 1;
							Map[i][j] = 0; Map[i + 1][j] = 0; Map[i + 1][j + 2] = 0;
							overloop = true;
						}
					}
					else if (Map[i + 1][j] == 1 && Map[i][j + 1] == 1 && j != 0) {//1
						if (Map[i + 1][j - 1] == 0 && Map[i + 1][j + 1] == 0 && Map[i + 2][j + 1] == 0) {
							Map[i + 1][j - 1] = 1; Map[i + 1][j + 1] = 1; Map[i + 2][j + 1] = 1;
							Map[i][j] = 0; Map[i][j + 1] = 0; Map[i + 2][j] = 0;
							overloop = true;
						}
					}
					else if (Map[i][j + 1] == 1 && Map[i + 1][j + 1] == 1 && j != 11 && j != 0) {//2
						if (Map[i - 1][j] == 0 && Map[i + 1][j] == 0 && Map[i + 1][j - 1] == 0) {
							Map[i - 1][j] = 1; Map[i + 1][j] = 1; Map[i + 1][j - 1] = 1;
							Map[i][j - 1] = 0; Map[i][j + 1] = 0; Map[i + 1][j + 1] = 0;
							overloop = true;
						}
					}
					else if (j != 0 && Map[i + 1][j] == 1 && Map[i + 1][j - 1] && j != 11) {//3
						if (Map[i - 1][j - 1] == 0 && Map[i][j - 1] == 0 && Map[i][j + 1] == 0) {
							Map[i - 1][j - 1] = 1; Map[i][j - 1] = 1; Map[i][j + 1] = 1;
							Map[i - 1][j] = 0; Map[i + 1][j] = 0; Map[i + 1][j - 1] = 0;
							overloop = true;
						}
					}
				}
				if (overloop == true)
					break;
			}
			if (overloop == true)
				break;
		}
		break;
	case 3:
		for (int i = 1; i != GameRegion_CellNumber_Height - 2; i++) { //1~21
			for (int j = 1; j != GameRegion_CellNumber_Width; j++) {
				if (Map[i][j] == 1) {
					if (Map[i][j + 1] == 1 && Map[i - 1][j + 1] == 1) {													//0
						if (Map[i - 1][j] == 0 && Map[i + 1][j] == 0 && Map[i + 1][j + 1] == 0) {
							Map[i - 1][j] = 1; Map[i + 1][j] = 1; Map[i + 1][j + 1] = 1;
							Map[i][j - 1] = 0; Map[i][j + 1] = 0; Map[i - 1][j + 1] = 0;
							overloop = true;
						}
					}
					else if (Map[i + 1][j] == 1 && Map[i + 1][j + 1] == 1 && j != 0) {									//1
						if (Map[i][j - 1] == 0 && Map[i + 1][j - 1] == 0 && Map[i][j + 1] == 0) {
							Map[i][j - 1] = 1; Map[i + 1][j - 1] = 1; Map[i][j + 1] = 1;
							Map[i - 1][j] = 0; Map[i + 1][j + 1] = 0; Map[i + 1][j] = 0;
							overloop = true;
						}
					}
					else if (j != 0 && j != 11 && Map[i][j - 1] == 1 && Map[i + 1][j - 1] == 1) {						//2
						if (Map[i - 1][j - 1] == 0 && Map[i - 1][j] == 0 && Map[i + 1][j] == 0) {
							Map[i - 1][j - 1] = 1; Map[i - 1][j] = 1; Map[i + 1][j] = 1;
							Map[i][j - 1] = 0; Map[i][j + 1] = 0; Map[i + 1][j - 1] = 0;
							overloop = true;
						}
					}
					else if (j != 0 && j != 11 && Map[i - 1][j - 1] == 1 && Map[i - 1][j]) {//3
						if (Map[i - 1][j + 1] == 0 && Map[i][j - 1] == 0 && Map[i][j + 1] == 0) {
							Map[i - 1][j + 1] = 1; Map[i][j - 1] = 1; Map[i][j + 1] = 1;
							Map[i - 1][j - 1] = 0; Map[i - 1][j] = 0; Map[i + 1][j] = 0;
							overloop = true;
						}
					}
				}
				if (overloop == true)
					break;
			}
			if (overloop == true)
				break;
		}
		break;
	case 4:
		for (int i = 1; i != GameRegion_CellNumber_Height - 2; i++) { //1~21
			for (int j = 1; j != GameRegion_CellNumber_Width; j++) {
				if (Map[i][j] == 1) {
					if (Map[i - 1][j] == 1 && Map[i - 1][j + 1] == 1) {//0
						if (Map[i][j + 1] == 0 && Map[i + 1][j + 1] == 0) {
							Map[i][j + 1] = 1; Map[i + 1][j + 1] = 1;
							Map[i][j - 1] = 0; Map[i - 1][j + 1] = 0;
							overloop = true;
						}
					}
					else if (Map[i][j + 1] == 1 && Map[i + 1][j + 1] == 1) {//1
						if (j != 0) {
							if (Map[i][j - 1] == 0 && Map[i - 1][j + 1] == 0) {
								Map[i][j - 1] = 1; Map[i - 1][j + 1] = 1;
								Map[i][j + 1] = 0; Map[i + 1][j + 1] = 0;
								overloop = true;
							}
						}
					}
				}
				if (overloop == true)
					break;
			}
			if (overloop == true)
				break;
		}
		break;
	case 5:
		for (int i = 1; i != GameRegion_CellNumber_Height - 2; i++) { //1~21
			for (int j = 1; j != GameRegion_CellNumber_Width; j++) {
				if (Map[i][j] == 1) {
					if (Map[i - 1][j] == 1 && Map[i][j + 1] == 1) {//0
						if (Map[i - 1][j + 1] == 0 && Map[i + 1][j] == 0) {
							Map[i - 1][j + 1] = 1; Map[i + 1][j] = 1;
							Map[i - 1][j - 1] = 0; Map[i - 1][j] = 0;
							overloop = true;
						}
					}
					else if (Map[i][j + 1] == 1 && Map[i - 1][j + 1] == 1) {//1
						if (j != 0) {
							if (Map[i][j - 1] == 0 && Map[i + 1][j + 1] == 0) {
								Map[i][j - 1] = 1; Map[i + 1][j + 1] = 1;
								Map[i - 1][j + 1] = 0; Map[i][j + 1] = 0;
								overloop = true;
							}
						}
					}
				}
				if (overloop == true)
					break;
			}
			if (overloop == true)
				break;
		}
		break;
	case 6:
		break;
	default:
		break;
	}
}

bool Boxs::check() {
	int GoalCount = 0;
	for (int i = 0; i != GameRegion_CellNumber_Height; i++) {				//0到23
		for (int j = 0; j != GameRegion_CellNumber_Width; j++) {			//0到11
			if (Map[i][j] == 0)
				break;														//检测下一行
			else if (j == 11) {
				for (int k = 0; k != GameRegion_CellNumber_Width; k++) {	//清空行
					Map[i][k] = 0;
				}
				GoalCount += 1;
				for (int m = i; m != 0; m--) {								//下移
					for (int n = 0; n != GameRegion_CellNumber_Width; n++) {
						Map[m][n] = Map[m - 1][n];
					}
				}
			}
		}
	}
	if (GoalCount == 1)
		goal += 10;
	if (GoalCount == 2)
		goal += 30;
	if (GoalCount == 3)
		goal += 60;
	if (GoalCount == 4)
		goal += 100;

	sprintf_s(text1, "当前分数：%d", goal);
	outtextxy(Window_Width - 150, Window_Height - 30, text1);
	//结束游戏
	if (Map[0][5] == 2)
		return true;
	else
		return false;

}

void Boxs::tip(int style, int direction) {
	int TipMap[4][4];
	memset(TipMap, 0, sizeof(TipMap));
	switch (style)
	{
	case 0:
		setfillcolor(RED);
		if (direction == 0 || direction == 2) {
			TipMap[1][0] = 1; TipMap[1][1] = 1; TipMap[1][2] = 1; TipMap[1][3] = 1;
		}
		else {
			TipMap[0][1] = 1; TipMap[1][1] = 1; TipMap[2][1] = 1; TipMap[3][1] = 1;
		}
		break;
	case 1:
		setfillcolor(GREEN);
		if (direction == 0) {
			TipMap[1][0] = 1; TipMap[1][1] = 1; TipMap[1][2] = 1; TipMap[0][1] = 1;
		}
		else if (direction == 1)
		{
			TipMap[2][1] = 1; TipMap[1][1] = 1; TipMap[1][2] = 1; TipMap[0][1] = 1;
		}
		else if (direction == 2)
		{
			TipMap[2][1] = 1; TipMap[1][1] = 1; TipMap[1][2] = 1; TipMap[1][0] = 1;
		}
		else if (direction == 3)
		{
			TipMap[2][1] = 1; TipMap[1][1] = 1; TipMap[1][0] = 1; TipMap[0][1] = 1;
		}
		break;
	case 2:
		setfillcolor(BROWN);
		if (direction == 0) {
			TipMap[0][0] = 1; TipMap[1][0] = 1; TipMap[1][1] = 1; TipMap[1][2] = 1;
		}
		else if (direction == 1)
		{
			TipMap[0][1] = 1; TipMap[0][2] = 1; TipMap[1][1] = 1; TipMap[2][1] = 1;
		}
		else if (direction == 2)
		{
			TipMap[1][0] = 1; TipMap[1][1] = 1; TipMap[1][2] = 1; TipMap[2][2] = 1;
		}
		else if (direction == 3)
		{
			TipMap[0][1] = 1; TipMap[1][1] = 1; TipMap[2][1] = 1; TipMap[2][0] = 1;
		}
		break;
	case 3:
		setfillcolor(BLUE);
		if (direction == 0) {
			TipMap[1][0] = 1; TipMap[1][1] = 1; TipMap[1][2] = 1; TipMap[0][2] = 1;
		}
		else if (direction == 1)
		{
			TipMap[0][1] = 1; TipMap[1][1] = 1; TipMap[2][1] = 1; TipMap[2][2] = 1;
		}
		else if (direction == 2)
		{
			TipMap[1][0] = 1; TipMap[1][1] = 1; TipMap[1][2] = 1; TipMap[2][0] = 1;
		}
		else if (direction == 3)
		{
			TipMap[0][0] = 1; TipMap[0][1] = 1; TipMap[1][1] = 1; TipMap[2][1] = 1;
		}
		break;
	case 4:
		setfillcolor(0xFF3EE9);
		if (direction == 0) {
			TipMap[0][1] = 1; TipMap[0][2] = 1; TipMap[1][0] = 1; TipMap[1][1] = 1;
		}
		else if (direction == 1)
		{
			TipMap[0][1] = 1; TipMap[1][1] = 1; TipMap[1][2] = 1; TipMap[2][2] = 1;
		}
		else if (direction == 2)
		{
			TipMap[2][0] = 1; TipMap[2][1] = 1; TipMap[1][2] = 1; TipMap[1][1] = 1;
		}
		else if (direction == 3)
		{
			TipMap[0][0] = 1; TipMap[1][0] = 1; TipMap[1][1] = 1; TipMap[2][1] = 1;
		}
		break;
	case 5:
		setfillcolor(0xEEF037);
		if (direction == 0) {
			TipMap[0][0] = 1; TipMap[0][1] = 1; TipMap[1][1] = 1; TipMap[1][2] = 1;
		}
		else if (direction == 1)
		{
			TipMap[0][2] = 1; TipMap[1][1] = 1; TipMap[1][2] = 1; TipMap[2][1] = 1;
		}
		else if (direction == 2)
		{
			TipMap[1][0] = 1; TipMap[1][1] = 1; TipMap[2][1] = 1; TipMap[2][2] = 1;
		}
		else if (direction == 3)
		{
			TipMap[0][1] = 1; TipMap[1][0] = 1; TipMap[1][1] = 1; TipMap[2][0] = 1;
		}
		break;
	case 6:
		setfillcolor(0xFFA500);
		TipMap[0][1] = 1; TipMap[0][2] = 1; TipMap[1][1] = 1; TipMap[1][2] = 1;
		break;
	default:
		//color = 0x000000;
		break;
	}
	clearrectangle(450, 60, 550, 160);
	//画
	int x = 450;
	int y = 60;
	int length = 20;
	for (int i = 0; i != 4; i++) {
		for (int j = 0; j != 4; j++) {
			if (TipMap[i][j] == 1) {
				fillrectangle(j * length + x, i * length + y, j * length + x + length, i * length + y + length);
			}
		}
	}
}

void initGame() {
	//绘制游戏区域
	fillrectangle(GameRegion_BorderLength, Window_Height - GameRegion_BorderLength,
		GameRegion_BorderLength, Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height);																		//左线
	fillrectangle(GameRegion_BorderLength, Window_Height - GameRegion_BorderLength,
		GameRegion_BorderLength + Block_Length * GameRegion_CellNumber_Width, Window_Height - GameRegion_BorderLength);																			//下线
	fillrectangle(GameRegion_BorderLength + Block_Length * GameRegion_CellNumber_Width, Window_Height - GameRegion_BorderLength,
		GameRegion_BorderLength + Block_Length * GameRegion_CellNumber_Width, Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height);							//左线
	fillrectangle(GameRegion_BorderLength + Block_Length * GameRegion_CellNumber_Width, Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height,
		GameRegion_BorderLength, Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height);																		//上线
	//绘制得分显示
	//char text1[25];
	sprintf_s(text1, "当前分数：%d", goal);
	outtextxy(Window_Width - 150, Window_Height - 30, text1);
	//绘制下一个方块提示	
	outtextxy(Window_Width - 135, 30, "下一个");
}

void ResetGameArea() {
	//清空游戏区域
	clearrectangle(GameRegion_BorderLength, Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height,
		GameRegion_BorderLength + Block_Length * GameRegion_CellNumber_Width, Window_Height - GameRegion_BorderLength);
	//绘制游戏边框
	fillrectangle(GameRegion_BorderLength, Window_Height - GameRegion_BorderLength,
		GameRegion_BorderLength, Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height);																		//左线
	fillrectangle(GameRegion_BorderLength, Window_Height - GameRegion_BorderLength,
		GameRegion_BorderLength + Block_Length * GameRegion_CellNumber_Width, Window_Height - GameRegion_BorderLength);																			//下线
	fillrectangle(GameRegion_BorderLength + Block_Length * GameRegion_CellNumber_Width, Window_Height - GameRegion_BorderLength,
		GameRegion_BorderLength + Block_Length * GameRegion_CellNumber_Width, Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height);							//左线
	fillrectangle(GameRegion_BorderLength + Block_Length * GameRegion_CellNumber_Width, Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height,
		GameRegion_BorderLength, Window_Height - GameRegion_BorderLength - Block_Length * GameRegion_CellNumber_Height);																		//上线
}