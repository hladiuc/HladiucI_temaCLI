1. Care este ordinea de desenare a vertexurilor pentru aceste metode (orar sau anti-orar)? Desenați axele de coordonate din aplicația- template folosind un singur apel GL.Begin().

Este sens anti-orar , dar putem modifica sa fie in sens orar , alterand coordonatele vertexurilor.

```csharp
private void DrawAxes()
{
    GL.LineWidth(2.0f); // linii mai groase , functioneaza doar daca apelul se afla in afara GL.Begin
    GL.PointSize(40.0f); // functioneaza daca GL.Begin are ca parametru PrimitiveType.Points , si face ca punctele sa fie mai groase

    // cu un singur apel GL.Begin
    GL.Begin(PrimitiveType.Lines);
    
    GL.Color3(Color.Red);
    GL.Vertex3(0, 0, 0);
    GL.Vertex3(XYZ_SIZE, 0, 0);

    GL.Color3(Color.Yellow);
    GL.Vertex3(0, 0, 0);
    GL.Vertex3(0, XYZ_SIZE, 0);

    GL.Color3(Color.Green);
    GL.Vertex3(0, 0, 0);
    GL.Vertex3(0, 0, XYZ_SIZE);

    GL.End();
}
```

2. Ce este anti-aliasing? Prezentați această tehnică pe scurt.

Anti-aliasing este o tehnica prin care imaginile devin mai netede, eliminand marginile zimtate("dintii") care apar atunci cand sunt afisate la rezolutii mai mici, imbunatatind astfel aspectul vizual al acestora.

3. Care este efectul rulării comenzii GL.LineWidth(float)? Dar pentru GL.PointSize(float)? Funcționează în interiorul unei zone GL.Begin()?

-> GL.LineWidth(float) - seteaza latimea liniilor randate in functie de parametrul primit
-> GL.PointSize(float) - seteza dimensiunea punctelor in functie de parametrul primit

Ambele trebuie apelate inaintea blocului GL.Begin pentru a functiona.

4. Răspundeți la următoarele întrebări (utilizați ca referință eventual și tutorii OpenGL Nate Robbins):
    * Care este efectul utilizării directivei LineLoop atunci când desenate segmente de dreaptă multiple în OpenGL?

    Uneste fiecare 2 puncte alaturate printr-o linie formand un "circuit inchis -> unind si primul punct cu ultimul".
    * Care este efectul utilizării directivei LineStrip atunci când desenate segmente de dreaptă multiple în OpenGL?

    Uneste fiecare 2 puncte alaturate printr-un segment , fara a forma un "circuit inchis" ca in cazul LineLoop.
    * Care este efectul utilizării directivei TriangleFan atunci când desenate segmente de dreaptă multiple în OpenGL?

    Directiva TriangleFan este o metoda de a desena triunghiuri, folosind un singur punct central la care se conecteaza toate triunghiurile. De exemplu, pentru a forma un cerc, toate triunghiurile se leaga de acest punct din mijloc. Astfel, se reduce numarul de coordonate necesare pentru a descrie figura, ceea ce mareste performanta randarii.
    * Care este efectul utilizării directivei TriangleStrip atunci când desenate segmente de dreaptă multiple în OpenGL?

    Directiva TriangleStrip este o metoda pentru a desena triunghiuri conectate intre ele. Fiecare triunghi nou se formeaza folosind ultimele doua vârfuri si un nou vârf adaugat. Aceasta metoda reduce numarul de coordonate necesare, economisind memorie. Este utila pentru a crea forme complexe si curbe, imbunatatind performanta in procesul de randare.

6. Urmăriți aplicația „shapes.exe” din tutorii OpenGL Nate Robbins. De ce este importantă utilizarea de culori diferite (în gradient sau culori selectate per suprafață) în desenarea obiectelor 3D? Care este avantajul?

    Fara umbre sau shadere, nu putem percepe formele tridimensionale ale obiectelor, ci vedem doar o singura culoare aplicata pe o forma ciudata. Asta face ca obiectele sa para plate si lipsit de detalii, reducand astfel impactul vizual si intelegerea formei reale.

7. Ce reprezintă un gradient de culoare? Cum se obține acesta în OpenGL?
    
    Un gradient de culoare este o tranzitie de la o culoare la alta. De exemplu, daca avem un gradient de la rosu la albastru, putem vedea nuante de violet intre ele.