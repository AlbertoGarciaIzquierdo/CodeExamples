// Alberto García Izquierdo - 2018

#include "ClockTimeActor.h"
#include "Runtime/Engine/Classes/GameFramework/Actor.h"
#include "TimerManager.h"


// Sets default values
AClockTimeActor::AClockTimeActor()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	
	/*_sunLight = CreateDefaultSubobject<UDirectionalLightComponent>(TEXT("Sun Light"));
	RootComponent = _sunLight;*/
}

// Called when the game starts or when spawned
void AClockTimeActor::BeginPlay()
{
	Super::BeginPlay();
	_timerDelay = DayLenght(_dayLenght);
	_gradesPerSecond = GradesPerSecond(_dayLenght);
	GetWorldTimerManager().SetTimer(_myTimeHandle, this, &AClockTimeActor::ClockFunction, _timerDelay, true);
}

// Called every frame
void AClockTimeActor::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

const float AClockTimeActor::DayLenght(float dayLenght)
{
	dayLenght = _dayLenght;
	return dayLenght / 24;
}

float AClockTimeActor::GradesPerSecond(float dayLenght)
{
	dayLenght = _dayLenght;
	_totalSeconds = dayLenght * 60;
	_grades = 360 / _totalSeconds;

	UE_LOG(LogTemp, Log, TEXT("TOTAL SECONDS: %f GRADES: %f"), _totalSeconds, _grades);
	return _grades;
}

void AClockTimeActor::ClockFunction()
{
		_minutes += 1;
		if (_minutes >= 60) {
			_minutes = 0;
			_hours += 1;
		}
		if (_hours >= 24)
			_hours = 0;

	UE_LOG(LogTemp, Log, TEXT("%02d:%02d"), _hours, _minutes);
}

