using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NuvemDeCinzas.ConsoleApp
{
    class Nuvem
    {
        int colunas, linhas, diaMinimo, diaMaximo = 1;
        List<string> mapa = new List<string>();
        Regex verificaAeroPortoNaLinha = new Regex(@"[A]");

        public string RetornarDias()
        {
            ConstruirMapa();

            if (ValidarMapa(mapa))
            {
                EspalhaNuvens();
                return diaMinimo + " " + diaMaximo;
            }

            return "";

        }

        private void EspalhaNuvens()
        {
            List<string> mapaAnterior = mapa;
            char[] linhaModificada ;
            char[] colunaModificada ;

            while (mapaAnterior.Exists(x => verificaAeroPortoNaLinha.IsMatch(x)))
            {
                for (int CoordenadaY = 0; CoordenadaY < mapaAnterior.Count; CoordenadaY++)
                {
                    linhaModificada = mapaAnterior[CoordenadaY].ToCharArray();

                    for (int CoordenadaX = 0; CoordenadaX < mapaAnterior[CoordenadaY].Length; CoordenadaX++)
                    {
                        if (mapaAnterior[CoordenadaY][CoordenadaX].Equals('#'))
                        {
                            bool possui = false;

                            if (diaMinimo == 0)
                                if (verificaAeroPortoNaLinha.IsMatch(mapaAnterior[CoordenadaY]))
                                    possui = true;

                            if (CoordenadaX > 0)
                                linhaModificada[CoordenadaX - 1] = '#';
                            if (CoordenadaX < linhaModificada.Length - 1)
                                linhaModificada[CoordenadaX + 1] = '#';
                            if (CoordenadaY > 0)
                            {
                                colunaModificada = mapaAnterior[CoordenadaY - 1].ToCharArray();
                                colunaModificada[CoordenadaX] = '#';
                                mapaAnterior[CoordenadaY] = colunaModificada.ToString();
                            }
                            if (CoordenadaY < mapaAnterior.Count() - 1)
                            {
                                colunaModificada = mapaAnterior[CoordenadaY + 1].ToCharArray();
                                colunaModificada[CoordenadaX] = '#';
                                mapaAnterior[CoordenadaY] = colunaModificada.ToString();
                            }
                            mapaAnterior[CoordenadaY] = linhaModificada.ToString(); 

                            if (possui && !verificaAeroPortoNaLinha.IsMatch(mapaAnterior[CoordenadaY]))
                                diaMinimo = diaMaximo;
                        }



                    }
                }
                diaMaximo++;
            }
        }
        private void ConstruirMapa()
        {
            Console.WriteLine("Digite L linhas e C colunas : \n");
            string linhasEColunas = Console.ReadLine();
            string[] arrayLinhasEColunas = linhasEColunas.Split(' ');
            linhas = Convert.ToInt32(arrayLinhasEColunas[0]);
            colunas = Convert.ToInt32(arrayLinhasEColunas[1]);

            Console.WriteLine("\nDigite " + linhas + " linhas com " + colunas + " colunas");

            for (int i = 0; i < linhas; i++)
                mapa.Add(Console.ReadLine());
        }
        private bool ValidarMapa(List<string> mapa)
        {
            bool temNuvem = false, temAero = false;

            for (int i = 0; i < mapa.Count(); i++)
                if (mapa[i].Length != colunas)
                    return false;

            for (int i = 0; i < mapa[0].Length; i++)
            {
                if (mapa.Exists(x => x[i] == ('#')))
                    temNuvem = true;
                if (mapa.Exists(x => x[i] == ('A')))
                    temAero = true;
            }

            if (temNuvem && temAero)
                return true;

            return false;
        }
    }
}