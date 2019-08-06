// Fill out your copyright notice in the Description page of Project Settings.

#include "CameraPawn.h"


// Sets default values
ACameraPawn::ACameraPawn()
{
 	// Set this pawn to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void ACameraPawn::BeginPlay()
{
	Super::BeginPlay();
	if (!_myCamera)
		_myCamera = NULL;
}

// Called every frame
void ACameraPawn::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	_result = _objVector - GetActorLocation();
	SetActorRotation(_result.Rotation());
	if (moving) {
		SetActorLocation(GetActorLocation() + GetActorRightVector() * _speedRot * FApp::GetDeltaTime());
	}
}

// Called to bind functionality to input
void ACameraPawn::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

	InputComponent->BindAxis("Zoom", this, &ACameraPawn::CameraZoom);
	InputComponent->BindAction("ZoomIn", IE_Pressed, this, &ACameraPawn::CameraZoomIn);
	InputComponent->BindAction("ZoomOut", IE_Pressed, this, &ACameraPawn::CameraZoomOut);
}

void ACameraPawn::CameraZoom(float AxisValue)
{
	SetActorLocation( GetActorLocation() + ( GetActorForwardVector() * AxisValue * _speed * FApp::GetDeltaTime() ) );
}

void ACameraPawn::CameraZoomIn()
{
	SetActorLocation(GetActorLocation() + (GetActorForwardVector() * _speed * FApp::GetDeltaTime()));
}

void ACameraPawn::CameraZoomOut()
{
	SetActorLocation(GetActorLocation() + (GetActorForwardVector() * -_speed * FApp::GetDeltaTime()));
}

