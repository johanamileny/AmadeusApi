import requests
import json
import time

url = "http://localhost:5222/api/destinations/new"

# Combinaciones organizadas según tu lógica del frontend
combinaciones = [
    # === PLAYA ===
    # Playa + Caluroso + 1-2 semanas + Menos de 30 años + Deportes y Aventuras + Hostal
    {   "questionOptionIds": [1, 4, 14, 16, 7, 11],  # Tulum + Ibiza
        "firstCityId": 2, "secondCityId": 9 },
    
    # Playa + Caluroso + 1-2 semanas + Menos de 30 años + Relax y Bienestar + Hotel de Lujo
    {   "questionOptionIds": [1, 4, 14, 16, 9, 10],  # Playa del Carmen + Santorini
        "firstCityId": 1, "secondCityId": 8 },
    
    # Playa + Caluroso + 1-2 semanas + 30-50 años + Cultura y Museos + Hotel de Lujo
    {   "questionOptionIds": [1, 4, 14, 17, 8, 10],  # Honolulu + Malta
        "firstCityId": 3, "secondCityId": 10 },
    
    # Playa + Caluroso + Menos de una semana + Menos de 30 años + Cultura y Museos + Airbnb
    {   "questionOptionIds": [1, 4, 13, 16, 8, 12],  # Cartagena + Barcelona
        "firstCityId": 4, "secondCityId": 11 },
    
    # Playa + Templado + 1-2 semanas + Menos de 30 años + Cultura y Museos + Hostal
    {   "questionOptionIds": [1, 5, 14, 16, 8, 11],  # San Juan + Niza
        "firstCityId": 15, "secondCityId": 28 },
    
    # Playa + Templado + 1-2 semanas + 30-50 años + Cultura y Museos + Hotel de Lujo
    {   "questionOptionIds": [1, 5, 14, 17, 8, 10],  # Río de Janeiro + Lisboa
        "firstCityId": 6, "secondCityId": 13 },
    
    # Playa + Templado + Más de dos semanas + Más de 50 años + Relax y Bienestar + Airbnb
    {   "questionOptionIds": [1, 5, 15, 18, 9, 12],  # Punta Cana + Algarve
        "firstCityId": 16, "secondCityId": 29 },
    
    # === MONTAÑA ===
    # Montaña + Frío + 1-2 semanas + Más de 50 años + Cultura y Museos + Airbnb
    {   "questionOptionIds": [2, 6, 14, 18, 8, 12],  # Ushuaia + Reykjavik
        "firstCityId": 17, "secondCityId": 30 },
    
    # Montaña + Frío + 1-2 semanas + Más de 50 años + Relax y Bienestar + Airbnb
    {   "questionOptionIds": [2, 6, 14, 18, 9, 12],  # Aspen + Innsbruck
        "firstCityId": 18, "secondCityId": 31 },
    
    # Montaña + Frío + 1-2 semanas + Menos de 30 años + Deportes y Aventuras + Hostal
    {   "questionOptionIds": [2, 6, 14, 16, 7, 11],  # Bariloche + Interlaken
        "firstCityId": 19, "secondCityId": 32 },
    
    # Montaña + Frío + 1-2 semanas + 30-50 años + Deportes y Aventuras + Hotel de Lujo
    {   "questionOptionIds": [2, 6, 14, 17, 7, 10],  # Banff + Zermatt
        "firstCityId": 20, "secondCityId": 33 },
    
    # Montaña + Templado + 1-2 semanas + Más de 50 años + Cultura y Museos + Airbnb
    {   "questionOptionIds": [2, 5, 14, 18, 8, 12],  # Cusco + Granada
        "firstCityId": 21, "secondCityId": 34 },
    
    # Montaña + Templado + Más de dos semanas + Menos de 30 años + Deportes y Aventuras + Airbnb
    {   "questionOptionIds": [2, 5, 15, 16, 7, 12],  # Machu Picchu + Chamonix
        "firstCityId": 22, "secondCityId": 35 },
    
    # === CIUDAD ===
    # Ciudad + Caluroso + 1-2 semanas + Más de 50 años + Cultura y Museos + Hotel de Lujo
    {   "questionOptionIds": [3, 4, 14, 18, 8, 10],  # Los Angeles + Roma
        "firstCityId": 23, "secondCityId": 36 },
    
    # Ciudad + Frío + 1-2 semanas + 30-50 años + Cultura y Museos + Hotel de Lujo
    {   "questionOptionIds": [3, 6, 14, 17, 8, 10],  # Toronto + Berlín
        "firstCityId": 24, "secondCityId": 37 },
    
    # Ciudad + Templado + 1-2 semanas + 30-50 años + Cultura y Museos + Hostal
    {   "questionOptionIds": [3, 5, 14, 17, 8, 11],  # Ciudad de México + Madrid
        "firstCityId": 25, "secondCityId": 38 },
    
    # Ciudad + Templado + 1-2 semanas + Más de 50 años + Cultura y Museos + Hotel de Lujo
    {   "questionOptionIds": [3, 5, 14, 18, 8, 10],  # Nueva York + París
        "firstCityId": 7, "secondCityId": 14 },
    
    # Ciudad + Templado + Menos de una semana + Menos de 30 años + Relax y Bienestar + Airbnb
    {   "questionOptionIds": [3, 5, 13, 16, 9, 12],  # Miami + Viena
        "firstCityId": 26, "secondCityId": 39 },
    
    # Ciudad + Templado + Menos de una semana + 30-50 años + Deportes y Aventuras + Hotel de Lujo
    {   "questionOptionIds": [3, 5, 13, 17, 7, 10],  # Chicago + Londres
        "firstCityId": 27, "secondCityId": 40 },
    
    # === COMBINACIÓN POR DEFECTO ===
    # Si no coincide ninguna combinación: Bora Bora + Dubai
    {   "questionOptionIds": [1, 4, 15, 17, 9, 10],  # Bora Bora + Dubai (default)
        "firstCityId": 5, "secondCityId": 12 }
]

def crear_destino(combinacion, index):
    """Crear un destino y mostrar el hash generado"""
    try:
        print(f"\n🔄 Combinación {index + 1}/{len(combinaciones)}:")
        print(f"   QuestionOptionIds: {combinacion['questionOptionIds']}")
        print(f"   FirstCityId: {combinacion['firstCityId']}")
        print(f"   SecondCityId: {combinacion['secondCityId']}")
        
        # El hash se generará automáticamente
        hash_esperado = ",".join(map(str, sorted(combinacion['questionOptionIds'])))
        print(f"   🔑 Hash que se generará: '{hash_esperado}'")
        
        headers = {'Content-Type': 'application/json'}
        response = requests.post(url, headers=headers, data=json.dumps(combinacion), timeout=10)
        
        if response.status_code == 200:
            print(f"   ✅ Éxito: Destino creado con hash '{hash_esperado}'")
            return True
        else:
            print(f"   ❌ Error {response.status_code}: {response.text}")
            return False
            
    except Exception as e:
        print(f"   ❌ Error: {e}")
        return False

def main():
    print("🚀 Iniciando creación de destinos organizados según lógica del frontend...")
    print(f"📊 Total de combinaciones: {len(combinaciones)}")
    
    success_count = 0
    failed_count = 0
    
    for i, combinacion in enumerate(combinaciones):
        if crear_destino(combinacion, i):
            success_count += 1
        else:
            failed_count += 1
            
        time.sleep(0.5)  # Pausa corta entre requests
    
    print(f"\n🎯 Proceso completado!")
    print(f"✅ Exitosos: {success_count}")
    print(f"❌ Fallidos: {failed_count}")
    print(f"📊 Total: {len(combinaciones)}")

if __name__ == "__main__":
    main()