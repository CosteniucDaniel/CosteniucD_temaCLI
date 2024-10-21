1. Ce este un viewport?
Un viewport în OpenGL este o regiune dreptunghiulară a ferestrei în care sunt desenate obiectele grafice. 
Practic, după ce obiectele 3D sunt proiectate pe ecran, ele sunt mapate pe această zonă specificată de viewport. 

2. Ce reprezintă conceptul de frames per second (FPS) din punctul de vedere al bibliotecii OpenGL?
În contextul OpenGL, frames per second (FPS) indică numărul de cadre complete (imagini) generate și afișate pe ecran într-o secundă.

3. Când este rulată metoda OnUpdateFrame()?
Metoda OnUpdateFrame() este rulată înainte de fiecare cadru (frame), fiind utilizată pentru actualizarea logicii aplicației, cum ar fi poziționarea obiectelor, 
procesarea intrărilor utilizatorului și alte actualizări care trebuie făcute în mod regulat în timpul rulării aplicației. Aceasta nu este responsabilă de randarea 
grafică propriu-zisă, ci doar de actualizarea stării scenei.

4. Ce este modul imediat de randare?
Modul imediat de randare este o metodă veche de desenare în OpenGL, în care toate punctele, liniile și poligoanele sunt specificate în mod direct în cadrul 
fiecărei apelări de randare, folosind funcții precum glBegin() și glEnd(). 

5. Care este ultima versiune de OpenGL care acceptă modul imediat?
Modul imediat de randare a fost suportat complet până la versiunea OpenGL 3.2. 

6. Când este rulată metoda OnRenderFrame()?
Metoda OnRenderFrame() este apelată pentru fiecare cadru atunci când scena este desenată efectiv. În această metodă se efectuează toate apelurile de randare OpenGL 
(cum ar fi desenarea obiectelor, aplicarea texturilor, etc.). 


7. De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată?
Metoda OnResize() trebuie executată cel puțin o dată pentru a seta corect dimensiunile viewport-ului și alte setări necesare pentru a 
adapta randarea grafică la dimensiunile ferestrei. De exemplu, când utilizatorul redimensionează fereastra aplicației, trebuie recalculată 
matricea de proiecție și trebuie ajustată dimensiunea viewport-ului, pentru a asigura că imaginea este redată corect în noile dimensiuni. 


8. Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul de valori pentru aceștia?
Metoda CreatePerspectiveFieldOfView() creează o matrice de proiecție pentru perspectiva camerei și are următorii parametri esențiali:

fieldOfView (câmpul vizual): unghiul în grade al câmpului vizual vertical. Un domeniu tipic de valori este între 30 și 120 de grade, unde valori mai mici oferă un efect de zoom, 
iar valori mai mari oferă o vedere mai largă.

aspectRatio (raportul de aspect): raportul dintre lățimea și înălțimea viewport-ului, folosit pentru a menține proporțiile imaginii. 
Acest raport este de obicei calculat ca lățimea împărțită la înălțimea ferestrei.

nearPlane (planul apropiat): distanța de la cameră până la planul apropiat al frustumului (volumul de vizualizare). 
Valorile uzuale sunt mici, dar pozitive (de exemplu, 0.1 sau 1.0).

farPlane (planul îndepărtat): distanța până la planul îndepărtat al frustumului. De obicei, are valori mari (de exemplu, 1000 sau mai mult), 
dar trebuie să fie suficient de departe pentru a include toate obiectele relevante.