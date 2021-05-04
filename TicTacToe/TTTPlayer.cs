using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public enum State
    {
        NotFinished,
        Victory,
        Defeated,
        Draw
    }
    class TTTPlayer
    {
        public int[,] arr;
        Random r = new Random();
        public TTTPlayer(int[,] arr, int turn=1)
        {
            this.arr = arr;
            rhash = new Dictionary<int, int[,]>();
            dp = new Dictionary<(int, int), int>();
            move = new Dictionary<(int, int), int>();
            buildTree(arr, turn);
        }

        Dictionary<int,int[,]> rhash;
        int getHash(int[,] arr)
        {
            int num = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    num = 3 * num + arr[i, j] + 1;
            rhash[num] = (int[,])arr.Clone();
            return num;
        }

        Dictionary<(int, int), int> dp, move;
        int buildTree(int[,] arr, int turn)
        {
            int hash = getHash(arr);
            if (dp.ContainsKey((hash, turn)))
                return dp[(hash, turn)];

            var status = CheckStatus(arr);
            if (status == State.Victory) return 1;
            if (status == State.Defeated) return -1;
            if (status == State.Draw) return 0;
            
            if(turn == -1)
            {
                int mn = 2;
                List<int> vals = new List<int>();
                for (int i=0; i<3; i++)
                    for(int j=0; j<3; j++)
                        if(arr[i,j] == 0)
                        {
                            arr[i, j] = turn;
                            int temp = buildTree(arr, -turn);
                            if (temp < mn)
                            {
                                mn = temp;
                                vals.Add(getHash(arr));
                            }
                            else if (temp == mn)
                                vals.Add(getHash(arr));
                            arr[i, j] = 0;
                            arr[i, j] = 0;
                        }
                dp[(hash, turn)] = mn;
                move[(hash, turn)] = vals[r.Next(vals.Count)];
                return mn;
            }else
            {
                int mx = -1;
                List<int> vals = new List<int>();
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if (arr[i, j] == 0)
                        {
                            arr[i, j] = turn;
                            int temp = buildTree(arr, -turn);
                            if (temp > mx)
                            {
                                mx = temp;
                                vals.Clear();
                                vals.Add(getHash(arr));
                            }else if(temp == mx)
                                vals.Add(getHash(arr));
                            arr[i, j] = 0;
                        }

                dp[(hash, turn)] = mx;
                move[(hash, turn)] = vals[r.Next(vals.Count)];
                return mx;
            }
        }

        public void PlayComputer()
        {
            int hash = getHash(arr);
            hash = move[(hash, 1)];
            arr = rhash[hash];
        }
        public bool PlayHuman(int i, int j)
        {
            if (CheckStatus(arr) != State.NotFinished) return false;
            if (arr[i, j] != 0) return false;
            arr[i,j] = -1;
            return true;
        }
        
        bool CheckEndGame(int[,] arr, int value)
        {
            for (int i = 0; i < 3; i++)
            {
                bool temp = true;
                for (int j = 0; j < 3; j++)
                    temp &= (arr[i, j] == value);
                if (temp) return true;

                temp = true;
                for (int j = 0; j < 3; j++)
                    temp &= (arr[j, i] == value);
                if (temp) return true;
            }
            bool victory = true;
            for (int i = 0; i < 3; i++)
                victory &= (arr[i, i] == value);
            if (victory) return true;
            victory = true;
            for (int i = 0; i < 3; i++)
                victory &= (arr[i, 2 - i] == value);
            if (victory) return true;

            return false;
        }
        State CheckStatus(int[,] arr)
        {
            if (CheckEndGame(arr, 1)) return State.Victory;
            if (CheckEndGame(arr, -1)) return State.Defeated;
            bool finished = true;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    finished &= (arr[i,j] != 0);
            if (finished) return State.Draw;
            return State.NotFinished;
        }

        public State Status()
        {
            return CheckStatus(arr);
        }

    }
}
