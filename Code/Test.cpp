#include <stdio.h>
#include <stdlib.h>
#define INP "DIJKSTRA.INP"
#define OUT "DIJKSTRA.OUT"
  
int main() {
    FILE *fi = fopen(INP, "r");
    FILE *fo = fopen(OUT, "w");
    int n, a, b, i, sum = 0;
  
    fscanf(fi, "%d%d%d", &n, &a, &b);
    int G[n][n];
    int S[n], Len[n], P[n];
  
    for (i = 0; i < n; i++)
        for (int j = 0; j < n; j++) {
            fscanf(fi, "%d", &G[i][j]);
            sum += G[i][j];
        }

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (i != j && G[i][j] == 0)
                G[i][j] = sum;
        }
    }
  
    a--;
    b--;
  
    for (int i = 0; i < n; i++) {
        Len[i] = sum;                   
        S[i] = 0;                      
        P[i] = a;                       
    }
  
    Len[a] = 0;                      
  

    while (S[b] == 0) {           
        for (i = 0; i < n; i++)        
            if (!S[i] && Len[i] < sum)
                break;
  
        if (i >= n) {
            printf("Thoat thuat toan Dijkstran\n");
            break;
        }
  
        for (int j = 0; j < n; j++) {   
            if (!S[j] && Len[i] > Len[j]) {
                i = j;
            }
        }
  
        S[i] = 1;                    
  
        for (int j = 0; j < n; j++) {    
            if (!S[j] && Len[i] + G[i][j] < Len[j]) {
                Len[j] = Len[i] + G[i][j];    
                P[j] = i;                      
            }
        }
    }
  
    printf("Tim duong di ngan nhat bang ma tran ke\n");
  
    printf("Bat dau tim kiem\n");
  
    if (Len[b] > 0 && Len[b] < sum) {
        fprintf(fo, "Do dai tu %d den %d la %d\n", a + 1, b + 1, Len[b]);
  
        // truy vet
        while (i != a) {
            fprintf(fo, "%d <-- ", i + 1);
            i = P[i];
        }
        fprintf(fo, "%d", a + 1);
    } else {
        fprintf(fo, "khong co duong di tu %d den %d\n", a + 1, b + 1);
    }
  
    printf("Ket thuc\n");
  
    fclose(fi);
    fclose(fo);
  
    printf("Hoan tat - mo file output de xem ket qua\n");
    return 0;
}
