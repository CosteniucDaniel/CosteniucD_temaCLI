2. Ce este anti-aliasing? Prezentați această tehnică pe scurt.

Anti-aliasing este o tehnică de netezire a marginilor zimțate din imagini digitale, reducând 
efectele de „pixelare” prin amestecarea culorilor de-a lungul contururilor. Aceasta face 
tranzițiile mai fluide și imaginea mai clară.

3. Care este efectul rulării comenzii GL.LineWidth(float)? Dar pentru
GL.PointSize(float)? Funcționează în interiorul unei zone
GL.Begin()?

GL.LineWidth(float) – Definește grosimea liniilor desenate.
GL.PointSize(float) – Setează dimensiunea punctelor desenate.
Comenzile GL.LineWidth(float) și GL.PointSize(float) nu funcționează corect 
dacă sunt apelate în interiorul unei secvențe GL.Begin() – GL.End().

4.Răspundeți la următoarele întrebări (utilizați ca referință eventual și
tutorii OpenGL Nate Robbins):
• Care este efectul utilizării directivei LineLoop atunci când
desenate segmente de dreaptă multiple în OpenGL?
• Care este efectul utilizării directivei LineStrip atunci când
desenate segmente de dreaptă multiple în OpenGL?
• Care este efectul utilizării directivei TriangleFan atunci când
desenate segmente de dreaptă multiple în OpenGL?
• Care este efectul utilizării directivei TriangleStrip atunci când
desenate segmente de dreaptă multiple în OpenGL?

GL.LineLoop: Desenează o linie între toate punctele specificate și conectează ultimul punct cu primul, formând un contur închis.

GL.LineStrip: Desenează o linie continuă între punctele specificate fără a închide bucla (ultimul punct nu se conectează la primul).

GL.TriangleFan: Creează un evantai de triunghiuri care împărtășesc un punct central (primul punct) și se extind la fiecare 
pereche de puncte consecutive.

GL.TriangleStrip: Desenează un șir de triunghiuri conectate, fiecare triunghi având două puncte comune cu cel anterior.

6. Culorile per suprafață permit diferențierea între diferitele 
părți sau elemente ale obiectului, facilitând înțelegerea structurii acestuia.

7. Ce reprezintă un gradient de culoare? Cum se obține acesta în
OpenGL?

Un gradient de culoare reprezintă o tranziție lină între două sau mai multe culori, folosită pentru a crea 
efecte de profunzime și lumină pe suprafețele 2D și 3D.
Un gradient de culoare în OpenGL se obține prin specificarea unor culori diferite pentru fiecare vârf al 
uni triunghi de exemplu. OpenGL va interpola automat culorile între aceste vârfuri, generând 
astfel un gradient pe suprafața obiectului.

10. Ce efect are utilizarea unei culori diferite pentru fiecare vertex
atunci când desenați o linie sau un triunghi în modul strip?

Atunci când utilizați o culoare diferită pentru fiecare vârf la desenarea unei linii sau a 
unui triunghi în modul strip, OpenGL va interpola 
culorile între vârfurile adiacente, generând un gradient de culoare de-a lungul obiectului.


 