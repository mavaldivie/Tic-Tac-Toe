# Juego de Tic Tac Toe usando el algoritmo Minimax

El programa consta de dos clases fundamentales, TTTPlayer que se encarga de manejar la logica del juego y Form1 que se encarga de mostrar el juego en una ventana de Windows Form.

Lo fundamental de la clase TTTPlayer es el metodo buildTree que se ocupa de visitar recursivamente el arbol de los posibles juegos y computar el mejor camino dada una configuracion inicial de la matriz del juego. Este metodo retorna 1, 0, -1 si la configuracion actual es ganadora, empate o perdedora para la IA. Se uso la tecnica de memoization para guardar dinamicamente los resultados de dicho algoritmo recursivo, asi como el camino optimo a tomar dada una configuracion del tablero. Se uso un random a la hora de elegir un camino optimo para la IA, en los casos de que posea mas de uno, para intentar demostrar un comportamiento menos mecanico por parte de la IA.

En la interfaz visual se muestran dos botones que se ocupan de iniciar un nuevo juego en el que comience la IA o el jugador, y un cuadro de texto que se ocupa de mostrar los resultados del juego. 
