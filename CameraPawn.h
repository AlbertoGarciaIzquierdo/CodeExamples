// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Pawn.h"
#include <Runtime/Core/Public/Misc/App.h>
#include "CameraPawn.generated.h"


UCLASS()
class MODELVIEWER_API ACameraPawn : public APawn
{
	GENERATED_BODY()

public:
	// Sets default values for this pawn's properties
	ACameraPawn();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

	UPROPERTY (EditAnywhere)
		ACameraActor* _myCamera = NULL;

	UPROPERTY(EditAnywhere)
		FVector _objVector = FVector(0 ,0 ,0);
	UPROPERTY(VisibleAnywhere)
		FVector _result;

	UPROPERTY (EditAnywhere)
		float _speed = 300;
	UPROPERTY(EditAnywhere)
		float _speedRot = 25;

	UPROPERTY(EditAnywhere)
		bool moving = false;

	//Input Functions
	void CameraZoom(float AxisValue);
	void CameraZoomIn();
	void CameraZoomOut();

};
