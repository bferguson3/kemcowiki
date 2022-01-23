#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    int i,j;
    time_t t;
    unsigned char bytes[16];

    srand((unsigned)time(&t));

    for(i = 0; i < 16; i++)
        bytes[i] = (unsigned char)(rand() % 255);

    bytes[6] &= 0xf;
    bytes[6] ^= 0x40;
    bytes[8] &= 0x3f;
    bytes[8] ^= 0x80;

    for(i = 0; i < 4; i++)
        printf("%02x", bytes[i]);
    for(j = 0; j < 3; j++)
    {
        printf("-");
        for(i = 0; i < 2; i++)
            printf("%02x", bytes[4+i+j]);
    }
    printf("-");
    for(i = 10; i < 16; i++)
        printf("%02x", bytes[i]);
    printf("\n");
    return 0;
}
