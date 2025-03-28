-- Insert the questions
INSERT INTO "Questions" ("Question_text") VALUES 
    ('¿Que tipo de entorno prefieres para tus vacaciones?'),
    ('¿Qué clima prefieres durante tus vacaciones?'),
    ('¿Qué tipo de actividades prefieres hacer durante tus vacaciones?'),
    ('¿Qué tipo de alojamiento prefieres?'),
    ('¿Cuánto tiemplo planeas quedarte de vacaciones?'),
    ('¿Cuál es tu rango de edad?');


-- TODO Insert the options for each question
-- Insert options for Question 1: "¿Que tipo de entorno prefieres para tus vacaciones?"
INSERT INTO "QuestionOptions" ("QuestionId", "Title", "Description", "Image") VALUES
    (1, 'Playa', 'Las playas no siempre son doradas?. Hay playas con arena negra volcánica, rosa coralina y hasta verde olivo. ¡Cada grano de arena cuenta una historia!', 'Resources/img/imagen1.jpg'),
    (1, 'Montaña', 'Las montañas tienen su propio clima?. Al subir una montaña, puedes experimentar diferentes climas en pocos kilómetros. ¡Es como viajar por el mundo sin salir de una misma montaña!', 'Resources/img/imagen2.jpg'),
    (1, 'Ciudad', 'Muchas ciudades tienen secretos subterráneos?. Bajo las calles de muchas ciudades se encuentran redes de túneles, ríos subterráneos y hasta antiguas ruinas. París, por ejemplo, tiene más de 200 kilómetros de túneles subterráneos.', 'Resources/img/imagen3.jpg'),

    -- Insert options for Question 2: "¿Qué clima prefieres durante tus vacaciones?"
    (2, 'Caluroso', 'En muchos lugares con clima cálido se celebran festivales y eventos al aire libre, aprovechando las altas temperaturas.', 'Resources/img/Tulum.jpg'),
    (2, 'Templado', 'Muchas de las rutas turísticas más famosas del mundo se encuentran en regiones con clima templado, como la Ruta de la Costa Amalfitana en Italia o la Ruta 66 en Estados Unidos.', 'Resources/img/Templado.jpg'),
    (2, 'Frío', 'En lugares con clima frío, el turismo se concentra principalmente en los meses de invierno, cuando la nieve cubre el paisaje y se pueden practicar deportes como el esquí, el snowboard y el patinaje sobre hielo.', 'Resources/img/Frio.jpg'),

    -- Insert options for Question 3: "¿Qué tipo de actividades prefieres hacer durante tus vacaciones?"
    (3, 'Deportes y Aventuras', 'Desde las montañas de Nepal hasta los ríos de Costa Rica, existen numerosos destinos que ofrecen experiencias únicas para los amantes de la adrenalina.', 'Resources/img/Aventura.jpg'),
    (3, 'Cultura y Museos', 'Al visitar los museos, los viajeros pueden imaginar cómo era la vida en la corte real y apreciar la arquitectura y el diseño de una época pasada.', 'Resources/img/cultura.jpg'),
    (3, 'Relax y Bienestar', 'Al visitar un baño termal, los viajeros pueden conectar con las tradiciones de culturas antiguas y experimentar una forma de relajación que ha sido practicada durante siglos.', 'Resources/img/relax.jpg'),

    -- Insert options for Question 4: "¿Qué tipo de alojamiento prefieres?"
    (4, 'Hotel de Lujo', 'Algunos de los hoteles más lujosos del mundo ofrecen experiencias tan exclusivas que incluyen la posibilidad de tener un mayordomo que se encargue de todos tus caprichos, desde preparar un baño relajante hasta hacer reservas en el restaurante más exclusivo.', 'Resources/img/hotelujo.jpg'),
    (4, 'Hostal o Albergue', 'Muchos de los hostales y albergues más populares del mundo se encuentran ubicados en edificios históricos o con una arquitectura única.', 'Resources/img/hostal.jpg'),
    (4, 'Airbnb', 'Airbnb o apartamento: Airbnb nació de una necesidad de alojamiento económico durante un evento en San Francisco.', 'Resources/img/airbnb.jpg'),

    -- Insert options for Question 5: "¿Cuánto tiemplo planeas quedarte de vacaciones?"
    (5, 'Menos de una semana', 'Estudios han demostrado que incluso viajes cortos pueden tener un impacto significativo en la reducción del estrés y la mejora del estado de ánimo.', 'Resources/img/findesemana.jpg'),
    (5, '1-2 semanas', 'Estudios han demostrado que este rango de tiempo permite sumergirte en la cultura local, conocer a fondo un lugar y crear recuerdos duraderos sin sentirte apresurado o abrumado.', 'Resources/img/dosemanas.jpg'),
    (5, 'Más de dos semanas', 'Viajes prolongados te permiten desconectar completamente de tu rutina diaria y volver a casa sintiéndote renovado y con una nueva perspectiva de la vida.', 'Resources/img/calendario.jpg'),

    -- Insert options for Question 6: "¿Cuál es tu rango de edad?"
    (6, 'Menos de 30 años', 'Viajar en la veintena te ayuda a desarrollar habilidades como la independencia, la adaptabilidad y la tolerancia a la incertidumbre, lo cual es fundamental para tu crecimiento personal.', 'Resources/img/veinte.jpg'),
    (6, '30-50 años', 'A menudo, se busca ir más allá de los destinos turísticos más populares y descubrir lugares menos conocidos, con una mayor conexión con la cultura local.', 'Resources/img/treinta.jpg'),
    (6, 'Más de 50 años', 'Muchos viajeros mayores se unen a grupos organizados para conocer a personas con intereses similares y compartir experiencias.', 'Resources/img/cincuenta.jpg');



-- TODO Insert citys
-- Insert cities with detailed information
INSERT INTO "Cities" ("Description", "Country", "Language", "Attraction", "Food", "ImagePath") VALUES 
    -- American/Latin American cities
    ('Playa del Carmen', 'México', 'Español', 'Chichén-Itzá', 'Salbutes', 'Resources/img/PlayaDelCarmen.jpg'),
    ('Tulum', 'México', 'Español', 'Cenote Calavera', 'Ceviche de Pescado', 'Resources/img/Tulum.jpg'),
    ('Honolulu', 'Hawái', 'Ingles/Hawaiano', 'Playa Hapuna', 'Saimin', 'Resources/img/Honolulu.jpg'),
    ('Cartagena', 'Colombia', 'Español', 'Castillo San Felipe', 'Cazuela de Mariscos', 'Resources/img/cartagena.jpg'),
    ('Bora Bora', 'Polinesia Francesa', 'Francés', 'Otemanu', 'Roulottes', 'Resources/img/BoraBora.jpg'),
    ('Río de Janeiro', 'Brasil', 'Portugués', 'Cristo Redentor', 'Feijoada', 'Resources/img/RioDeJaneiro.jpg'),
    ('Nueva York', 'EE.UU', 'Inglés', 'Central Park', 'Pizza', 'Resources/img/NuevaYork.jpg'),

    -- European/Middle Eastern cities
    ('Santorini', 'Grecia', 'Griego', 'Oia', 'Hummus de Fava', 'Resources/img/Santorini.jpg'),
    ('Ibiza', 'España', 'Castellano/Catalán', 'Islote Es Vedrá', 'Sofrit pagès', 'Resources/img/ibiza.jpg'),
    ('Malta', 'Malta', 'Ingles/Maltés', 'La Valeta', 'Aljotta', 'Resources/img/Malta.jpg'),
    ('Barcelona', 'España', 'Castellano/Catalán', 'Sagrada Familia', 'Pa amb tomàquet', 'Resources/img/Barcelona.jpg'),
    ('Dubai', 'Emiratos Árabes', 'Árabe', 'Burj Al Arab', 'El Mezze', 'Resources/img/dubai.jpg'),
    ('Lisboa', 'Portugal', 'Portugués', 'Tranvía 28', 'Pasteles de Belem', 'Resources/img/lisboa.jpg'),
    ('París', 'Francia', 'Frances', 'Torre Eiffel', 'Foie gra', 'Resources/img/paris.jpg');

INSERT INTO "Destinations" ("Combination", "FirstCityId","SecondCityId") VALUES

