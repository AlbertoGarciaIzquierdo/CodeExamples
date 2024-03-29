// Alberto García Izquierdo - 2018

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Runtime/Engine/Classes/Components/DirectionalLightComponent.h"
#include "ClockTimeActor.generated.h"


UCLASS()
class MYPROJECT_API AClockTimeActor : public AActor
{
	GENERATED_BODY()
	


public:	
	// Sets default values for this actor's properties
	AClockTimeActor();

	//	VARIABLES
	UPROPERTY(EditAnywhere, BlueprintReadOnly, Category = "Time Parameters")
		float _dayLenght;
	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Time Parameters")
		float _timerDelay;
	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Time Parameters")
		float _gradesPerSecond;
	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Time Parameters")
		int _minutes;
	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Time Parameters")
		int _hours;

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

	/*UPROPERTY(VisibleAnywhere, BlueprintReadWrite, Category = "Light Setup")
	UDirectionalLightComponent* _sunLight;*/
	FTimerHandle _myTimeHandle;
	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Time Parameters")
	float _grades;
	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Time Parameters")
	float _totalSeconds;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	UFUNCTION()
		const float DayLenght(float dayLenght);
	UFUNCTION()
		float GradesPerSecond(float dayLenght);
	UFUNCTION()
		void ClockFunction();
};
