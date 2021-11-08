% http://www.oz8afn.dk/-Tinas-hjemmeside-/gaader/1-Hvem-ejer-zebraen.html
% M[X]: [Color, Nationality, Pet, Drink, Brand]
% nth1(Index?, List?, Element?)

valid(I) :- I > 0, I < 6.
leftOf(From, Left) :- valid(From), valid(Left), succ(Left, From).
rightOf(From, Right) :- valid(From), valid(Right), succ(From, Right).
nextTo(From, Side) :- leftOf(From, Side) ; rightOf(From, Side).

% Englænderen bor i det røde hus.
hint2(M) :- nth1(_, M, [red, english, _, _, _]).

% Svenskeren har hund.
hint3(M) :- nth1(_, M, [_, swedish, dog, _, _]).

% Danskeren drikker te.
hint4(M) :- nth1(_, M, [_, danish, _, tea, _]).

% Der drikkes kaffe i det grønne hus.
hint5(M) :- nth1(_, M, [green, _, _, coffee, _]).

% Det grønne hus ligger til venstre for det hvide hus.
hint6(M) :- 
    nth1(From, M, [white, _, _, _, _]),
    nth1(Left, M, [green, _, _, _, _]),
    leftOf(From, Left).

% Manden, der ryger Long, holder fugle.
hint7(M) :- nth1(_, M, [_, _, birds, _, long]).

% I det gule hus ryger man Kings.
hint8(M) :- nth1(_, M, [yellow, _, _, _, kings]).

% I det midterste hus drikker man mælk.
hint9(M) :- nth1(3, M, [_, _, _, milk, _]).

% Manden, der ryger Cecil, 
% bor i huset ved siden af det hus, 
% hvor der holdes kat.
hint10(M) :- 
    nth1(From, M, [_, _, cat, _, _]),
    nth1(Side, M, [_, _, _, _, cecil]),
    nextTo(From, Side).

% Nordmanden bor i det første hus.
hint11(M) :- nth1(1, M, [_, norwegian, _, _, _]).

% Man ryger Kings i det hus, 
% der ligger ved siden af huset, 
% hvor man har hest.
hint12(M) :- 
    nth1(From, M, [_, _, horse, _, _]),
    nth1(Side, M, [_, _, _, _, kings]),
	nextTo(From, Side).

% Manden, der ryger North State, drikker øl.
hint13(M) :- nth1(_, M, [_, _, _, beer, north_state]).

% Tyskeren ryger Prince
hint14(M) :- nth1(_, M, [_, german, _, _, prince]).

% Nordmanden bor ved siden af det blå hus.
hint15(M) :- 
    nth1(From, M, [blue, _, _, _, _]),
    nth1(Side, M, [_, norwegian, _, _, _]),
	nextTo(From, Side).

% Man drikker vand i det hus, 
% der ligger ved siden af det hus, 
% hvor man ryger Cecil.
hint16(M) :-
    nth1(From, M, [_, _, _, _, cecil]),
    nth1(Side, M, [_, _, _, water, _]),
    nextTo(From, Side).

% Zebra fundet
addZebra(M) :- nth1(_, M, [_, _, zebra, _, _]).

% Løs gåde
solve(M) :-
    M = [
		[_, _, _, _, _],
		[_, _, _, _, _],
		[_, _, _, _, _],
		[_, _, _, _, _],
		[_, _, _, _, _]
    ],
    hint2(M),
    hint3(M),
    hint4(M),
    hint5(M),
    hint6(M),
    hint7(M),
    hint8(M),
    hint9(M),
    hint10(M),
    hint11(M),
    hint12(M),
    hint13(M),
    hint14(M),
    hint15(M),
    hint16(M),
    addZebra(M)
    .