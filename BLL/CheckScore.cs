using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class CheckScore
    {
        public async Task<string> canfinish(int score)
        {
            string outtext = null;
            string D = null;
            string T1 = null;
            string T2 = null;
            int i = 0;

            bool single = false;
            bool doubl = false;
            int half = score / 2;
            int checkscore = score;



            if (checkscore > 100)
            {
                for (i = 0; i < 21; i++)
                {
                    checkscore = checkscore - i;
                    if (checkscore < 101)
                    {
                        single = true;
                        outtext += i.ToString() + " ";
                        break;
                    }
                    checkscore = checkscore + i;
                }
            }

            if (single == false)
            {
                if (checkscore > 120)
                {
                    for (i = 0; i < 21; i++)
                    {
                        checkscore = checkscore - (i * 2);
                        if (checkscore < 101)
                        {
                            doubl = true;
                            D = "D" + i.ToString() + " ";
                            break;
                        }
                        checkscore = checkscore + (i * 2);
                    }
                    outtext += D;
                }
            }

            if (single == false && doubl == false)
            {
                if (checkscore > 140)
                {
                    for (i = 0; i < 21; i++)
                    {
                        checkscore = checkscore - (i * 3);
                        if (checkscore < 101)
                        {
                            T1 = "T" + i.ToString() + " ";
                            break;
                        }
                        checkscore = checkscore + (i * 3);
                    }
                    outtext += T1;
                }
            }


            for (i = 0; i < 21; i++)
            {
                checkscore = checkscore - (i * 3);
                if (checkscore < 41)
                {
                    half = checkscore / 2;
                    T2 = "T" + i.ToString() + " ";
                    break;
                }
                checkscore = checkscore + (i * 3);
            }
            outtext += T2;

            if (half % 2 == 0 && checkscore < 41)
            {
                outtext += "D" + half.ToString();
            }
            else
            {
                outtext = null;
            }
            return outtext;
        }
        public async Task<bool> LegalScore(int score)
        {
            if(score > -1 && score < 181)
            {
                return true;
            }
            else
            {
                throw new Exception("illegal score");
            }
        }
    }
}
